using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string AgentFirstName { get;set; }
        public string AgentLastName { get;set; }
        public string Qualification { get;set; }
        public string Email { get;set; }
        public Int32 Phone { get;set; }
        public Double CommissionEarned { get;set; }
        public bool Status { get;set; }

        public List<Customer>?Customers { get;set; } 
        public User?User { get;set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; } // Fk -->1 UserId
    }
}
