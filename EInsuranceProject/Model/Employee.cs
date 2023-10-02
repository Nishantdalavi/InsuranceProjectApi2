using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; } 
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Phone { get; set; }
        public string Email { get;set; }
        public Double Salary { get;set; }
        public bool Status { get; set; }



        public User? User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}
