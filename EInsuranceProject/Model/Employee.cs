using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee First Name is required.")]
        [StringLength(50, ErrorMessage = "Employee First Name should not exceed 50 characters.")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required.")]
        [StringLength(50, ErrorMessage = "Employee Last Name should not exceed 50 characters.")]
        public string EmployeeLastName { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be a 10-digit number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get;set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public Double Salary { get;set; }
        public bool Status { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }      
    }
}
