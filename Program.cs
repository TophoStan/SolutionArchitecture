using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupplierManagementService.Application;
using SupplierManagementService.Domain.Events;
using SupplierManagementService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your services and repositories
builder.Services.AddSingleton<SupplierRepository>();
builder.Services.AddSingleton<EventPublisher>();
builder.Services.AddSingleton<SupplierService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

var eventConsumer = new EventConsumer();
eventConsumer.ConsumeEvents<SupplierRegisteredEvent>();

app.Run();
