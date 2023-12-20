using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IInsurancePlanService
    {
        public Task<IEnumerable<InsurancePlan>> GetAll(string[] innerTables);
        public Task<InsurancePlan> GetById(int Id);
        public Task AddInsurancePlan(InsurancePlan plan);
        public Task<bool> UpdatePlan(InsurancePlan plan);
        public Task<bool> DeletePlan(int id);
    }
}
