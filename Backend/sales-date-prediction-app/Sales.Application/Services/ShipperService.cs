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
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
        public IEnumerable<Shipper> GetShippers()
        {
            return _shipperRepository.GetShippers();
        }
    }
}
