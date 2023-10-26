using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;

namespace sales_date_prediction_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet()]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = _customerService.GetSaleDatePrediction();
            return customers;
        }
    }
}
