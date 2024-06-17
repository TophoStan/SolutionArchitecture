using BallComSolution.Infrastructure;
using BallComSolution.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SupplierDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2))));

// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<EventPublisher>();
builder.Services.AddScoped<SupplierService>();

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

Console.WriteLine("BallComSolution is running!");

app.Run();
