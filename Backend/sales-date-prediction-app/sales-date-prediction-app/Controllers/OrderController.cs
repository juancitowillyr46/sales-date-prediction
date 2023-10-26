using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;

namespace sales_date_prediction_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{customerId}")]
        public IEnumerable<Order> Get(int customerId)
        {
            IEnumerable<Order> orders = _orderService.GetClientOrders(customerId);
            return orders;
        }

        [HttpPost()]
        public bool Post([FromBody] CreateOrder createOrder)
        {
            bool success = _orderService.CreateOrder(createOrder);
            return success;
        }
    }
}
