using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Ports.Outbound
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
