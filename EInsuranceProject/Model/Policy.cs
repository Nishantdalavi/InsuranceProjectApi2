namespace EInsuranceProject.Model
{
    public class Policy
    {
        public int PolicyNo { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly MaturityDate { get; set; }
        public Mode PremiumMode { get; set; }   
        public double Premium { get; set; }
        public double SumAssured { get;set; }
        public bool Status { get;set; }


    }
}
