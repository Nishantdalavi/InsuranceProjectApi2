using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Policy
    {
        [Key]
        public int PolicyNo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public Mode PremiumMode { get; set; }   
        public double Premium { get; set; }
        public double SumAssured { get;set; }
        public bool Status { get;set; }
        public List<Customer> Customers { get; set; }  
        public List<Payment> Payment { get; set; }
        public InsuranceScheme InsuranceScheme { get; set; }

    }
}
