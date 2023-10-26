using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Outbound;
using Sales.Infrastructure.Database;
using Sales.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Adapters
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SaleDatePredictionDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper, SaleDatePredictionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool CreateOrder(CreateOrder createOrder)
        {

            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@EmployeeID", createOrder.EmployeeID),
                new SqlParameter("@ShipperID", createOrder.ShipperID),
                new SqlParameter("@ShipName", createOrder.ShipName),
                new SqlParameter("@ShipAddress", createOrder.ShipAddress),
                new SqlParameter("@ShipCity", createOrder.ShipCity),
                new SqlParameter("@Freight", createOrder.Freight),
                new SqlParameter("@ShipCountry", createOrder.ShipCountry),
                new SqlParameter("@ProductID", createOrder.ProductID),
                new SqlParameter("@UnitPrice", createOrder.UnitPrice),
                new SqlParameter("@Qty", createOrder.Qty),
                new SqlParameter("@Discount", createOrder.Discount),
                new SqlParameter("@DateAudit", createOrder.DateAudit?.ToString())
            };

            string sql = "EXEC [Sales].[SP_CreateNewOrder] " +
                        "@EmployeeID, @ShipperID, @ShipName, @ShipAddress, " +
                        "@ShipCity, @Freight, @ShipCountry, @ProductID, " +
                        "@UnitPrice, @Qty, @Discount, @DateAudit";
            OrderModel? create = _context.Orders?.FromSqlRaw(sql, parameters.ToArray()).AsEnumerable().First();
            return (create?.OrderId > 0);
        }

        public IEnumerable<Order> GetClientOrders(int customerId)
        {
            IEnumerable<OrderModel>? toListOrder = _context.Orders?.FromSqlRaw("EXEC [Sales].[SP_GetClientOrders] @CustomerID = {0}", customerId).ToList();
            return _mapper.Map<IEnumerable<Order>>(toListOrder);
        }
    }
}
