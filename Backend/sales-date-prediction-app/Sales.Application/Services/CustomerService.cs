using AutoMapper;
using Sales.Domain.Entities;
using Sales.Domain.Ports.Inbound;
using Sales.Domain.Ports.Outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        IEnumerable<Customer> ICustomerService.GetSaleDatePrediction()
        {
            return _customerRepository.GetSaleDatePrediction();
        }
    }
}
