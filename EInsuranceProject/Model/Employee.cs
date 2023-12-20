using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = " First Name should not exceed 50 characters")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = " Last Name should not exceed 50 characters")]
        public string EmployeeLastName { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be 10-digit")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress (ErrorMessage ="Invalid format")]
        public string Email { get;set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public Double Salary { get;set; }
        public bool Status { get; set; }


        //[ForeignKey("User")]
        //public int UserId { get; set; }
        //public User? User { get; set; }      
    }
}
