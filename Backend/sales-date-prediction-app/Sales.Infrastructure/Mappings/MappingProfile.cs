using AutoMapper;
using Sales.Domain.Entities;
using Sales.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<OrderModel, Order>();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<ShipperModel, Shipper>();
            CreateMap<ProductModel, Product>();
        }
    }
}
