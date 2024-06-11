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
        var factory = new ConnectionFactory() { HostName = "localhost", Port= 5672};
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "ball_exchange", type: "fanout");
    }

    public void Publish<T>(T @event)
    {
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "ball_exchange",
                             routingKey: "",
                             basicProperties: null,
                             body: body);
    }
}
