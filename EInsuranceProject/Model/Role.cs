using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public List<User> Users { get; set; }

    }
}
