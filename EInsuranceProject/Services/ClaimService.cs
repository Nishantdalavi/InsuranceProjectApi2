using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class ClaimService : IClaimService
    {
        private IEntityRepository<Claim> _repository;
        public ClaimService(IEntityRepository<Claim> repository)
        {
            _repository = repository;
        }
        public async Task AddClaim(Claim claim)
        {
            await _repository.Insert(claim);
        }

        public async Task<bool> DeleteClaim(int id)
        {
            var ClaimToDelete = await _repository.GetById(id);
            if (ClaimToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Claim Data found");
        }

        public async Task<IEnumerable<Claim>> GetAll(string[] innerTables)
        {
            Expression<Func<Claim, bool>> filterPredicate = e => e.Status == true;
            var claims = await _repository.GetAll(innerTables, filterPredicate);
            if (claims.Any())
            {
                return claims;
            }
            throw new DataNotFoundExcpetion("No Claim Data found");
        }

        public async Task<Claim> GetById(int Id)
        {
            var Claim = await _repository.GetById(Id);
            if (Claim != null)
            {
                return Claim;
            }
            throw new DataNotFoundExcpetion("No Claim Data Found");
        }

        public async Task<bool> UpdateClaim(Claim claim)
        {
            var ClaimToUpdate = await _repository.GetById(claim.ClaimId);
            if (ClaimToUpdate != null)
                return await _repository.Update(claim, claim.ClaimId);
            throw new DataNotFoundExcpetion("No Claim Data found");
        }
    }
}
