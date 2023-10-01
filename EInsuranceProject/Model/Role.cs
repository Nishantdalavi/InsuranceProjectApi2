namespace EInsuranceProject.Model
{
    public class Role
    {
        public int roleId { get;set; }
        public string roleName { get;set; } 

        public List<User> Users { get; set; }

    }
}
