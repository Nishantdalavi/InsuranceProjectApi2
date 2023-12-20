using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IClaimService
    {
        public Task<IEnumerable<Claim>> GetAll(string[] innerTables);
        public Task<Claim> GetById(int Id);
        public Task AddClaim(Claim claim);
        public Task<bool> UpdateClaim(Claim claim);
        public Task<bool> DeleteClaim(int id);
    }
}
