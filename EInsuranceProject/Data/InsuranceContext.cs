using EInsuranceProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace EInsuranceProject.Data
{
    public class InsuranceContext:DbContext
    {
     
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Policy>Agents { get; set; }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }
        public DbSet<Admin> Payments { get; set; }
        public DbSet<Policy> Policies { get; set; }
       public DbSet<SchemeDetails> SchemeDetails { get; set; }
        public DbSet<Claim> Claims { get; set; }    
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceScheme>()
                  .HasOne(I => I.SchemeDetails).WithOne(d => d.InsuranceScheme).HasForeignKey<SchemeDetails>(d => d.DetailId);
        }
        public InsuranceContext(DbContextOptions<InsuranceContext>options):base(options){ }

    }
}
