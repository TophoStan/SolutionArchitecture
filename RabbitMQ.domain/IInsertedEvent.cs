﻿using MassTransit;

namespace RabbitMQ.domain;

// Make it so RabbitMQ.domain.IInsertedEvent is named IInsertedEvent in the exchange

public interface IInsertedEvent
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Price { get; set; }
    public int StockQuantity { get; set; }


}

