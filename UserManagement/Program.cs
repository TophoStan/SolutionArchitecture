using MassTransit;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RabbitMQ.domain;
using UserManagement.Infrastructure;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

var mySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<UserMySQLContext>(options => options.UseMySql(mySQLConnectionString, new MySqlServerVersion(new Version(8, 0, 2))));

var mongoDBConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
var client = new MongoClient(mongoDBConnectionString);
var database = client.GetDatabase("ReadUser");
builder.Services.AddSingleton(database);
builder.Services.AddScoped<UserMongoDBContext>();

var rabbitMQHostName = builder.Configuration["RABBITMQ_HOSTNAME"];
#pragma warning disable ASP0012 // Suggest using builder.Services over Host.ConfigureServices or WebHost.ConfigureServices
builder.Host.ConfigureServices(services =>
{
    services.AddMassTransit(x =>
    {
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(rabbitMQHostName, "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });

            //cfg.ReceiveEndpoint("user-support-queue", e =>
            //{
            //    e.ConfigureConsumer<SupportConsumer>(context);
            //    e.Bind("ballcom", x =>
            //    {
            //        x.RoutingKey = "user-support-key";
            //        x.ExchangeType = "topic";
            //    });
            //});

            cfg.Message<ISupportTicketCreatedEvent>(x =>
            {
                x.SetEntityName("support-ticket-created-event");
            });

            cfg.Publish<ISupportTicketCreatedEvent>(x =>
            {
                x.ExchangeType = "topic";
            });
        });
    });
    // Add the bus to the container
});

// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CsvImportService>();

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

Console.WriteLine("User management is running!");
Console.WriteLine("Running in environment: " + app.Environment.EnvironmentName);

app.Run();
