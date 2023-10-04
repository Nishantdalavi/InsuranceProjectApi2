using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        [Required(ErrorMessage = "Agent First Name is required.")]
        [StringLength(50, ErrorMessage = "Agent First Name should not exceed 50 characters.")]
        public string AgentFirstName { get;set; }

        [Required(ErrorMessage = "Agent Last Name is required.")]
        [StringLength(50, ErrorMessage = "Agent Last Name should not exceed 50 characters.")]
        public string AgentLastName { get;set; }

        [StringLength(100, ErrorMessage = "Qualification should not exceed 100 characters.")]
        public string Qualification { get;set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get;set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be a 10-digit number.")]
        public Int32 Phone { get;set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Commission Earned must be greater than 0.")]
        public Double CommissionEarned { get;set; }
        public bool Status { get;set; }

        public List<Customer>?Customers { get;set; }

        [ForeignKey("User")]
        public int UserId { get; set; } // Fk -->1 UserId
        public User?User { get;set; }  
    }
}
