using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class AgentService : IAgentService
    {
        private IEntityRepository<Agent> _repository;

        public AgentService(IEntityRepository<Agent> entityRepository)
        {
            _repository = entityRepository;
        }
        public async Task AddAgent(Agent agent)   {
           await  _repository.Insert(agent);
        }

        public async Task<bool> DeleteAgent(int id)
        {
            var AgentToDelete = await _repository.GetById(id);
            if (AgentToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Agent Data found");
        }

        public async Task<IEnumerable<Agent>> GetAll(string[] innerTables)
        {
            Expression<Func<Agent, bool>> filterPredicate = e => e.Status == true;
            var agents=await _repository.GetAll(innerTables, filterPredicate);
            if(agents.Any())
            {
                return agents;
            }
            throw new DataNotFoundExcpetion("No agent Data found");
        }

        public async Task<Agent> GetById(int Id)
        {
            var agent=await _repository.GetById(Id);
            if(agent!=null)
            {
                return agent;
            }
            throw new DataNotFoundExcpetion("No agent Data found");
        }

        public async Task<bool> UpdateAgent(Agent agent)
        {
            var agentToUpdate = await _repository.GetById(agent.AgentId);
            if(agentToUpdate!=null)
            {
                return await _repository.Update(agent, agent.AgentId);
            }
            throw new DataNotFoundExcpetion("No Agent Data found");
        }
    }
}
