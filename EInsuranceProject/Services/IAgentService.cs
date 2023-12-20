using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IAgentService
    {
        public Task<IEnumerable<Agent>> GetAll(string[] innerTables);
        public Task<Agent> GetById(int Id);
        public Task AddAgent(Agent agent);
        public Task<bool> UpdateAgent(Agent agent);
        public Task<bool> DeleteAgent(int id);
    }
}
