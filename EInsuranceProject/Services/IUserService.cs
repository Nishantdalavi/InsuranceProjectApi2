using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll(string[] innerTables);
        public Task<User> GetById(int Id);
        public Task AddUser(User user);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(int id);

    }
}
