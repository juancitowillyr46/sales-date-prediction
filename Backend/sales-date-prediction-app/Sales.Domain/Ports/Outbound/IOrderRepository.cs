using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Ports.Outbound
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetClientOrders(int customerId);
        bool CreateOrder(CreateOrder createOrder);
    }
}
