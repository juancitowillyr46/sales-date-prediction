using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? LastOrderDate { get; set; }
        public string? NextPredictedOrder { get; set; }

    }
}
