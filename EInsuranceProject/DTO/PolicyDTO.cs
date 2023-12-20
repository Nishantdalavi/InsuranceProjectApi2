using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class PolicyDTO
    {
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
        public double SumAssured { get; set; }
        public bool Status { get; set; }
        public int CustomersCount { get; set; }
        public int PaymentCount { get; set; }
        
    }
}
