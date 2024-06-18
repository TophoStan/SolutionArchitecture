using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BallComSolution.Infrastructure;

public class EventConsumer
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    public EventConsumer()
    {
        var hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME");


        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "ball_exchange", type: "fanout");

        _queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: _queueName,
                           exchange: "ball_exchange",
                           routingKey: "");
    }

    public void ConsumeEvents<T>()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<T>(message);
            // Process the event here
            Console.WriteLine($"Received event: {@event}");
        };

        _channel.BasicConsume(queue: _queueName,
                              autoAck: true,
                              consumer: consumer);
    }
}