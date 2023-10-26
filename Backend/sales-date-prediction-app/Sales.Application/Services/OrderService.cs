using AutoMapper;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool CreateOrder(CreateOrder createOrder)
        {
            bool success = _orderRepository.CreateOrder(createOrder);
            return success;
        }

        public IEnumerable<Order> GetClientOrders(int customerId)
        {
            return _orderRepository.GetClientOrders(customerId);
        }
    }
}
