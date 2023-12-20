using EInsuranceProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.DTO
{
    public class InsurancePlanDTO
    {
        public int PlanId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PlanName { get; set; }
        public bool Status { get; set; }

        public int  SchemesCount { get; set; }
    }
}
