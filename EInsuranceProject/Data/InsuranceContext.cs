using EInsuranceProject.Model;
using Microsoft.EntityFrameworkCore;

namespace EInsuranceProject.Data
{
    public class InsuranceContext:DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agent>Agents { get; set; }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Customer> Customers { get; set; }
      

        public InsuranceContext(DbContextOptions<InsuranceContext>options):base(options){ }

    }
}
