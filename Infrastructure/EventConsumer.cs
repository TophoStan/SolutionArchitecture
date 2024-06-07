﻿namespace SupplierManagementService.Infrastructure;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;

public class EventConsumer
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    public EventConsumer()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "supplier_exchange", type: "fanout");

        _queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: _queueName,
                           exchange: "supplier_exchange",
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

