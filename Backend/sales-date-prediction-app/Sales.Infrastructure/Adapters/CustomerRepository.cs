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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SaleDatePredictionDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(IMapper mapper, SaleDatePredictionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Customer> GetSaleDatePrediction()
        {
            IEnumerable<CustomerModel>? toListCustomer = _context.Customers?.FromSqlRaw("EXEC [Sales].[SP_GetSaleDatePrediction]").ToList();
            return _mapper.Map<IEnumerable<Customer>>(toListCustomer);
        }
    }
}
