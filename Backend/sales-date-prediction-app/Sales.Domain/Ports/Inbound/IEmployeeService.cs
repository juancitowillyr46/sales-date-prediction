using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Ports.Inbound
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
    }
}
