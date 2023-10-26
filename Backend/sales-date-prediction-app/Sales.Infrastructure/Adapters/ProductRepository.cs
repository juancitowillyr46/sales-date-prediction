using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Outbound;
using Sales.Infrastructure.Database;
using Sales.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Adapters
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaleDatePredictionDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper, SaleDatePredictionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<ProductModel>? toListCustomer = _context.Products?.FromSqlRaw("EXEC [Sales].[SP_GetProducts]").ToList();
            return _mapper.Map<IEnumerable<Product>>(toListCustomer);
        }
    }
}
