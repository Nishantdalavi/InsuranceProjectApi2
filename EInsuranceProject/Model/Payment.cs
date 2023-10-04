using System.ComponentModel.DataAnnotations;

namespace EInsuranceProject.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get;set; }       
        public PaymentType paymentType { get;set; }


        public List<Policy> Policies { get;set; }
    }
}
