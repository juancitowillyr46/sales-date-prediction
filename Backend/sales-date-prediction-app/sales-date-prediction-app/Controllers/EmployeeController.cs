using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;

namespace sales_date_prediction_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet()]
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> employees = _employeeService.GetEmployees();
            return employees;
        }
    }
}
