using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminFirstName { get; set; }  
        public string AdminLastName { get; set; }


        public User? User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}
