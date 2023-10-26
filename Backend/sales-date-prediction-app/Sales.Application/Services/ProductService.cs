using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;
using Sales.Domain.Ports.Outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
