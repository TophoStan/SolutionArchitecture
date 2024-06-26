using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.domain;

public interface IPaymentConfirmedEvent
{
    public string PaymentId { get; set; }
    public string OrderId { get; set; }
    public Dictionary<int, int> ProductIdQuantity { get; set; }
}
