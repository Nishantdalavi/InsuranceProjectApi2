using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Email { get;set; }
        public Int32 Phone {  get; set; } 
        public string Address { get; set; }
        public State State { get; set; }
        public string City { get;set; }
        public string Nominee { get;set; }
        public string NomineeRelation { get;set; }
        public bool Status { get;set; }

        public List<Agent>? Agents { get; set; }
        public List<Document>Documents { get; set; }

        public User? User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
