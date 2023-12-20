using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Claim
    {
        [Key]
        
        public int ClaimId { get; set; }

        public double ClaimAmount { get; set; }
        [Required (ErrorMessage ="This field is required")]
        public DateTime ClaimDate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string BankAccountNo { get;set; }
        [Required(ErrorMessage = "This field is required")]
        public string BankIFSCCode { get;set; }
        public bool Status { get; set; }

        public List<Policy> ?Policies { get; set; }
    }
}
