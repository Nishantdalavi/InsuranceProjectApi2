using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class InsurancePlan
    {
        [Key]
        public int PlanId { get;set; }
        [Required(ErrorMessage = "This field is required")]
        public string PlanName { get;set; }
        public bool Status { get; set; }

        public List<InsuranceScheme>?Schemes { get; set; }                   
    }
}
