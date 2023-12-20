using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress (ErrorMessage ="Invalid format") ]
        [StringLength(20)]
        public string Email { get;set; }

        [Required(ErrorMessage = "This field is required")]
        [Phone (ErrorMessage ="Phone number should be  10-digit")]
        public string Phone {  get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public State State { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string City { get;set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100)]
        public string Nominee { get;set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string NomineeRelation { get;set; }
        public bool Status { get;set; }

        public List<Agent>? Agents { get; set; }

        public List<Complaint> ?Queries { get; set; }
        public List<Document>? Documents { get; set; }

        public List<Policy> ?Policies { get; set; }   
        //public User? User { get; set; }
        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
   
      
    }
}
