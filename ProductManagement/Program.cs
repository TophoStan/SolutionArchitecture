using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductManagement.Infrastructure;
using ProductManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

builder.Configuration.AddEnvironmentVariables();



var mySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");


if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
{
    mySQLConnectionString = mySQLConnectionString.Replace("localhost", "mysql");
}

Console.WriteLine("MySQL Connection String: " + mySQLConnectionString);

builder.Services.AddDbContext<ProductMySQLContext>(options => options.UseMySql(mySQLConnectionString, new MySqlServerVersion(new Version(8, 0, 2))));



var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
{
    mongoDBConnectionString = mongoDBConnectionString.Replace("localhost", "mongo");
}
var client = new MongoClient(mongoDBConnectionString);
var database = client.GetDatabase("ReadSupplier");
builder.Services.AddSingleton(database);
builder.Services.AddScoped<ProductMongoDBContext>();


// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<EventPublisher>();

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

Console.WriteLine("Productmanagement is running!");
Console.WriteLine("Running in environment: " + app.Environment.EnvironmentName);


//var eventConsumer = new EventConsumer();
//eventConsumer.ConsumeEvents<ProductRegisteredEvent>();



app.Run();
