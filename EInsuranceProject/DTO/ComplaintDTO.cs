using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class ComplaintDTO
    {
        public int ComplaintId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ComplaintName { get; set; }
        public string ? ComplaintMessage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime DateOfComplaint { get; set; }
        public bool Status { get;set; }
        
      
    }
}
