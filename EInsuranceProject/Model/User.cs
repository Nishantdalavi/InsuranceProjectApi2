using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }= String.Empty;

        //[Required]
        public List<Role> Roles { get; set; }
        public Admin Admin { get; set; }
        public Agent Agent { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }  

    }
}
