using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class InsurancePlan
    {
        [Key]
        public int PlanId { get;set; }
        public string PlanName { get;set; }
        public bool Staus { get; set; }

        public List<InsuranceScheme>Schemes { get; set; }                   
    }
}
