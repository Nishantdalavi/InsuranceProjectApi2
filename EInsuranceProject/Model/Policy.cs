using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Policy
    {
        [Key]
        public int PolicyNo { get; set; }
        [Required]
        
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime MaturityDate { get; set; }
        [Required]
        public Mode PremiumMode { get; set; }
        [Required]
        public double Premium { get; set; }
        [Required]
        public double SumAssured { get;set; }
        public bool Status { get;set; }
        public List<Customer>?Customers { get; set; }  
        public List<Payment>? Payments { get; set; }
        public InsuranceScheme? InsuranceScheme { get; set; }
        public List<Claim>?Claims { get; set; }

    }
}
