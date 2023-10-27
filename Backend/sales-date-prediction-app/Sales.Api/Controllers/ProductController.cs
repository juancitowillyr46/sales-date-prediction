using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;

namespace sales_date_prediction_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> products = _productService.GetProducts();
            return products;
        }
    }
}
