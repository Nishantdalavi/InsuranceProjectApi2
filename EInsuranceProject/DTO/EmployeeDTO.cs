using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "First Name should not exceed 50 characters")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Last Name should not exceed 50 characters")]
        public string EmployeeLastName { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be  10-digit ")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid format")]
        public string Email { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public Double Salary { get; set; }
        public bool Status { get; set; }  
      //  public int UserId { get; set; }
      
    }
}
