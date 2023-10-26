using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Models
{
    public class ShipperModel
    {
        [Key]
        public int ShipperId { get; set; }
        public string? CompanyName { get; set;}
    }
}
