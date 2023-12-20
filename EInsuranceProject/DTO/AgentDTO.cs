using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class AgentDTO
    {
        public int AgentId { get; set; }
        //public int UserId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [StringLength(50, ErrorMessage = "First Name should not exceed 50 characters")]
        public string AgentFirstName { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        [StringLength(50, ErrorMessage = "Last Name should not exceed 50 characters")]
        public string AgentLastName { get; set; }

        [StringLength(100, ErrorMessage = "Qualification should not exceed 100 characters")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [EmailAddress(ErrorMessage = "Invalid format")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be 10-digit ")]
        public string Phone { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Commission Earned must be greater than 0")]
        public Double CommissionEarned { get; set; }
        public bool Status { get; set; }

        public int CustomersCount { get; set; }

       
       

    }
}
