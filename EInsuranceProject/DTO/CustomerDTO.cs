using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        // public int UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress (ErrorMessage ="Invalid format")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone (ErrorMessage ="Phone number should be 10-digit")]
        public string Phone { get; set; }

        [StringLength(100)]
        public string ?Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public State State { get; set; }

        [StringLength(50)]
        public string ?City { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100)]
        public string Nominee { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string NomineeRelation { get; set; }
        public bool Status { get; set; }

        public int  AgentsCount { get; set; }

        public int QueryCount { get; set; }
        public int DocumentsCount { get; set; }

        public int  PoliciesCount { get; set; }
     
    }
}
