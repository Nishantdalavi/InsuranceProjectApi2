namespace EInsuranceProject.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }    
        public string Password { get;set; }
       
        public List<Role> Roles { get; set; }


        // One-to one Relationship to Roles
        public Agent? Agent { get; set; }
        public Admin?Admin { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
    }
}
