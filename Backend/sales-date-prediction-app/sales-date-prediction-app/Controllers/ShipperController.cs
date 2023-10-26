using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;

namespace sales_date_prediction_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet()]
        public IEnumerable<Shipper> Get()
        {
            IEnumerable<Shipper> shippers = _shipperService.GetShippers();
            return shippers;
        }
    }
}
