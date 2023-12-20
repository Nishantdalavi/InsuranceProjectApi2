using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public double Tax { get; set; }
        public double TotalPayment { get; set; }
        public bool Status { get; set; }

        public int PoliciesCount { get; set; }
    }
}
