using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get;set; }
        [Required]
        [Phone]
        [StringLength(20)]
        public Int32 Phone {  get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public State State { get; set; }

        [StringLength(50)]
        public string City { get;set; }

        [StringLength(100)]
        public string Nominee { get;set; }

        [StringLength(50)]
        public string NomineeRelation { get;set; }
        public bool Status { get;set; }

        public List<Agent>? Agents { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
      
    }
}
