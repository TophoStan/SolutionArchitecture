using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Order;
using OrderManagement.Infrastructure.Product;
using OrderManagement.Infrastructure.User;
using OrderManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

var mySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<OrderMySQLContext>(options => options.UseMySql(mySQLConnectionString, new MySqlServerVersion(new Version(8, 0, 2))));

var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
var client = new MongoClient(mongoDBConnectionString);
var database = client.GetDatabase("ReadOrder");
builder.Services.AddSingleton(database);
builder.Services.AddScoped<OrderMongoDBContext>();

// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<EventPublisher>();

builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

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

Console.WriteLine("Order management is running!");
Console.WriteLine("Running in environment: " + app.Environment.EnvironmentName);

app.Run();
