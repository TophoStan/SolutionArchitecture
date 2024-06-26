using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.domain;

public interface IPaymentConfirmedEvent
{
    public string PaymentId { get; set; }
    public string OrderNumber { get; set; }
    public Dictionary<int, int> ProductIdQuantity { get; set; }
    public string UserName { get; set; }
    public string SupplierName { get; set; }
}
