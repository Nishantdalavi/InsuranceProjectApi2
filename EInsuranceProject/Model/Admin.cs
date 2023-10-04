using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Admin First Name is required.")]
        [StringLength(50, ErrorMessage = "Admin First Name should not exceed 50 characters.")]
        public string AdminFirstName { get; set; }

        [Required(ErrorMessage = "Admin Last Name is required.")]
        [StringLength(50, ErrorMessage = "Admin Last Name should not exceed 50 characters.")]
        public string AdminLastName { get; set; }

        [Required(ErrorMessage = "UserId is required.")]

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
