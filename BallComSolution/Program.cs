using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SupplierManagement.Domain.Events;
using SupplierManagement.Infrastructure;
using SupplierManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");



var mySQLConnectionString = builder.Configuration.GetConnectionString("mySQLConnection");


if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
{
    mySQLConnectionString = mySQLConnectionString.Replace("localhost", "mysql");
}
mySQLConnectionString = builder.Configuration.GetConnectionString("mySQLConnectionDev");

builder.Services.AddDbContext<SupplierMySQLContext>(options => options.UseMySql(mySQLConnectionString, new MySqlServerVersion(new Version(8, 0, 2))));



var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
{
    mongoDBConnectionString = mongoDBConnectionString.Replace("localhost", "mongo");
}
var client = new MongoClient(mongoDBConnectionString);
var database = client.GetDatabase("ReadSupplier");
builder.Services.AddSingleton(database);
builder.Services.AddScoped<SupplierMongoDBContext>();


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
Console.WriteLine("Running in environment: " + app.Environment.EnvironmentName);


var eventConsumer = new EventConsumer();
eventConsumer.ConsumeEvents<SupplierRegisteredEvent>();



app.Run();
