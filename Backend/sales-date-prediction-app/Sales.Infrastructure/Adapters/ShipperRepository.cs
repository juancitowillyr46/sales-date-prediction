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
    public class ShipperRepository : IShipperRepository
    {
        private readonly SaleDatePredictionDbContext _context;
        private readonly IMapper _mapper;

        public ShipperRepository(IMapper mapper, SaleDatePredictionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Shipper> GetShippers()
        {
            IEnumerable<ShipperModel>? toListCustomer = _context.Shippers?.FromSqlRaw("EXEC [Sales].[SP_GetShippers]").ToList();
            return _mapper.Map<IEnumerable<Shipper>>(toListCustomer);
        }
    }
}
