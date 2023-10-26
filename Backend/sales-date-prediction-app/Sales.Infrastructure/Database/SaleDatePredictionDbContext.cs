using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Models;

namespace Sales.Infrastructure.Database
{
    public class SaleDatePredictionDbContext : DbContext
    {
        public SaleDatePredictionDbContext()
        {
        }

        public SaleDatePredictionDbContext(DbContextOptions<SaleDatePredictionDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<CustomerModel>? Customers { get; set; }
        public DbSet<OrderModel>? Orders { get; set; }
        public DbSet<EmployeeModel>? Employees { get; set; }
        public DbSet<ShipperModel>? Shippers { get; set; }
        public DbSet<ProductModel>? Products { get; set; }
    }
}
