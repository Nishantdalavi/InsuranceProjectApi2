using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IPolicyService
    {
        public Task<IEnumerable<Policy>> GetAll(string[] innerTables);
        public Task<Policy> GetById(int Id);
        public Task AddPolicy(Policy policy);
        public Task<bool> UpdatePolicy(Policy policy);
        public Task<bool> DeletePolicy(int id);
    }
}
