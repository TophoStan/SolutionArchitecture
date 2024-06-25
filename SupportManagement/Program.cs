using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SupportManagement.Infrastructure;
using SupportManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

var mySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<SupportMySQLContext>(options => options.UseMySql(mySQLConnectionString, new MySqlServerVersion(new Version(8, 0, 2))));

var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
var client = new MongoClient(mongoDBConnectionString);
var database = client.GetDatabase("ReadSupport");
builder.Services.AddSingleton(database);
builder.Services.AddScoped<SupportMongoDBContext>();

// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<SupportService>();
builder.Services.AddScoped<SupportRepository>();

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

Console.WriteLine("Support management is running!");
Console.WriteLine("Running in environment: " + app.Environment.EnvironmentName);

app.Run();
