using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class SchemeDetailDTO
    {
        public int DetailId { get; set; }
        public string SchemeImage { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Int32 MinAmount { get; set; }
        [Required]
        public Int32 MaxAmount { get; set; }
        [Required]
        public int MinAge { get; set; }
        [Required]
        public int MaxAge { get; set; }
        public bool Status { get;set; }
        //public int SchemeId { get; set; }

        
    }
}
