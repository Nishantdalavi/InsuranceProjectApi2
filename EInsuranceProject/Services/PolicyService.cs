using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class PolicyService : IPolicyService
    {
        private IEntityRepository<Policy> _repository;
        public PolicyService(IEntityRepository<Policy>repository) 
        {
            _repository = repository;

        }

        public async Task AddPolicy(Policy policy)
        {
            await _repository.Insert(policy);
        }

        public async Task<bool> DeletePolicy(int id)
        {
            var PolicyToDelete = await _repository.GetById(id);
            if (PolicyToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Policy Data found");
        }

        public async Task<IEnumerable<Policy>> GetAll(string[] innerTables)
        {
            Expression<Func<Policy, bool>> filterPredicate = e => e.Status == true;
            var policies = await _repository.GetAll(innerTables, filterPredicate);
            if (policies.Any())
            {
                return policies;
            }
            throw new DataNotFoundExcpetion("No policy Data found");
        }

        public async Task<Policy> GetById(int Id)
        {
            var policy = await _repository.GetById(Id);
            if (policy != null)
            {
                return policy;
            }
            throw new DataNotFoundExcpetion("No policy Data found");
        }

        public async Task<bool> UpdatePolicy(Policy policy)
        {
            var policyToUpdate = await _repository.GetById(policy.PolicyNo);
            if (policyToUpdate != null)
            {
                return await _repository.Update(policy, policy.PolicyNo);
            }
            throw new DataNotFoundExcpetion("No Policy Data found");
        }
    }
}
