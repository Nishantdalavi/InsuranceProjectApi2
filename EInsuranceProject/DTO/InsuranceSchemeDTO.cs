using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class InsuranceSchemeDTO
    {
        public int SchemeId { get; set; }
        [Required (ErrorMessage ="This field is required")]
        public string SchemeName { get; set; }
        public bool Status { get; set; }
       
        public int PoliciesCount { get; set; }
        public int PlansCount { get; set; }
    }
}
