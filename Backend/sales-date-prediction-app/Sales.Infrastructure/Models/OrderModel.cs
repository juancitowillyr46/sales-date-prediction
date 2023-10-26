using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public string? RequiredDate { get; set; }
        public string? ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
    }
}
