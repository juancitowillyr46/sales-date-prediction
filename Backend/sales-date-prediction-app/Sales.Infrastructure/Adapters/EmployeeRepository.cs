using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Outbound;
using Sales.Infrastructure.Database;
using Sales.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Adapters
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SaleDatePredictionDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(IMapper mapper, SaleDatePredictionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<EmployeeModel>? toListEmployee = _context.Employees?.FromSqlRaw("EXEC [HR].[SP_GetEmployees]").ToList();
            return _mapper.Map<IEnumerable<Employee>>(toListEmployee);
        }
    }
}
