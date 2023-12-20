using EInsuranceProject.Data;
using EInsuranceProject.MiddleWare;
using EInsuranceProject.Repository;
using EInsuranceProject.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EInsuranceProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Add Context 
            builder.Services.AddDbContext<InsuranceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
            });
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers()
       .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddTransient(typeof(IEntityRepository<>),typeof(EntityRepository<>));
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IAgentService, AgentService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IInsurancePlanService, InsurancePlanService>();
            builder.Services.AddTransient<IInsuranceSchemesService, InsuranceSchemesService>();
            builder.Services.AddTransient<IPolicyService, PolicyService>();
            builder.Services.AddTransient<IDocumentService, DocumentService>();
            builder.Services.AddTransient<ISchemeDetailsService, SchemeDetailsService>();
            builder.Services.AddTransient<IAdminService, AdminService>();
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<IComplaintService, ComplaintService>();
            builder.Services.AddTransient<IClaimService, ClaimService>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlingMiddleWare>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}