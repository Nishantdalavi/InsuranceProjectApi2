using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class SchemeDetails
    {
        [Key]
        public int DetailId { get;set; }
        public string SchemeImage { get; set; }
        [Required]
        public string Description { get;set; }
        [Required]
        public Int32 MinAmount { get; set; }
        [Required]
        public Int32 MaxAmount { get; set;}
        [Required]
        public int MinAge { get; set; }
        [Required]
        public int MaxAge { get; set; }
        [Required]
        public ClaimType ClaimType { get; set; }
        public bool Status { get; set; }

        public InsuranceScheme InsuranceScheme { get; set; }
        //[ForeignKey("ScemeId")]
        //public int SchemeId { get; set; }   
           
      

    }
}
