using BallComSolution.Domain.Events;
using BallComSolution.Infrastructure;
using BallComSolution.Services;

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

Console.WriteLine("BallComSolution is running!");
var eventConsumer = new EventConsumer();
eventConsumer.ConsumeEvents<SupplierRegisteredEvent>();

app.Run();
