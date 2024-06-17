using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BallComSolution.Infrastructure;

public class EventPublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventPublisher()
    {
        var hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME");
        Console.WriteLine(hostname);


        var factory = new ConnectionFactory() { HostName = hostname };

        _connection = factory.CreateConnection();
        Console.WriteLine("Connection created");

        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "ball_exchange", type: "fanout");
        Console.WriteLine("Declared exchange");
    }

    public void Publish<T>(T @event)
    {
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);


        Console.WriteLine($"Publishing event: {@event}");


        _channel.BasicPublish(exchange: "ball_exchange",
                             routingKey: "",
                             basicProperties: null,
                             body: body);
    }
}
