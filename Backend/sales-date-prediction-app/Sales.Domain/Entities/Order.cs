using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? RequiredDate { get; set; }
        public string? ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
    }

    public class CreateOrder
    {
        public int EmployeeID { get; set; }
        public int ShipperID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public decimal Freight { get; set; }
        public string? ShipCountry { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
        public string? DateAudit { get; set; }
    }
}
