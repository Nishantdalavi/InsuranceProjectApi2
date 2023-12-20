using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class InsuranceScheme
    {
        [Key]
        public int SchemeId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string SchemeName { get;set; }
        public bool Status { get;set; }


        public SchemeDetails SchemeDetails { get; set; }
    

        public List<Policy>? Policies { get; set; }
        public List<InsurancePlan>? Plans { get; set; }


    }
}
