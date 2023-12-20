using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class InsuranceSchemesService : IInsuranceSchemesService
    {
        private IEntityRepository<InsuranceScheme> _repository;
        public InsuranceSchemesService(IEntityRepository<InsuranceScheme> repository)
        {
            _repository = repository;
        }

        public async Task AddScheme(InsuranceScheme scheme)
        {
          await _repository.Insert(scheme);
        }

        public async Task<bool> DeleteScheme(int id)
        {
            var SchemeToDelete = await _repository.GetById(id);
            if (SchemeToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Scheme Data found");
        }

        public async Task<IEnumerable<InsuranceScheme>> GetAll(string[] innerTables)
        {
            Expression<Func<InsuranceScheme, bool>> filterPredicate = e => e.Status == true;
            var Schemes = await _repository.GetAll(innerTables, filterPredicate);
            if (Schemes.Any() )
            {
                return Schemes;
            }
            throw new DataNotFoundExcpetion("No Scheme Data found");
        }

        public async Task<InsuranceScheme> GetById(int Id)
        {
            var Scheme = await _repository.GetById(Id);
            if (Scheme != null)
            {
                return Scheme;
            }
            throw new DataNotFoundExcpetion("No Scheme Data found");
        }

        public async Task<bool> UpdateScheme(InsuranceScheme scheme)
        {
            var SchemeToUpdate = await _repository.GetById(scheme.SchemeId);
            if (SchemeToUpdate != null)
            {
                return await _repository.Update(scheme, scheme.SchemeId);
            }
            throw new DataNotFoundExcpetion("No scheme Data found");
        }
    }
}
