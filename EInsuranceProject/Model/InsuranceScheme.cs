namespace EInsuranceProject.Model
{
    public class InsuranceScheme
    {
        public int SchemeId { get; set; }
        public string SchemeName { get;set; }
        public bool Status { get;set; }
        public List<InsurancePlan>Plans { get; set; }

        

    }
}
