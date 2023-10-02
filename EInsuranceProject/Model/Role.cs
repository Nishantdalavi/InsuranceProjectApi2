using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Role
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }

        public List<User> Users { get; set; }

    }
}
