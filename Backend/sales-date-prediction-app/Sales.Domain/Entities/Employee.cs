using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? FullName { get; set; }
    }
}
