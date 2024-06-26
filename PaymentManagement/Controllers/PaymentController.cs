using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PaymentManagement.Domain;
using RabbitMQ.domain;

namespace PaymentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IBus _bus;

        public PaymentController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Payment payment)
        {
            // Publish PaymentConfirmedEvent
            IPaymentConfirmedEvent @event = new PaymentConfirmedEvent();
            @event.OrderNumber = payment.OrderNumber;
            @event.UserName = payment.UserName;
            @event.SupplierName = payment.SupplierName;
            @event.ProductIdQuantity = payment.ProductIdQuantity;



            await _bus.Publish(@event, x =>
            {
                x.SetRoutingKey("payment-confirmed-routingkey");
            });
            return Ok();
        }
    }
}
