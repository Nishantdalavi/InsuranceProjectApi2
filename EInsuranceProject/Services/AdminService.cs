using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class AdminService : IAdminService
    {
        private IEntityRepository<Admin> _repository;
        public AdminService(IEntityRepository<Admin> repository)
        {
            _repository = repository;
        }
        public async Task AddAdmin(Admin admin)
        {
            await _repository.Insert(admin);
        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var AdminToDelete = await _repository.GetById(id);
            if (AdminToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No admin Data found");
        }

        public async Task<IEnumerable<Admin>> GetAll(string[] innerTables)
        {
            Expression<Func<Admin, bool>> filterPredicate = e => e.Status == true;
            var admins = await _repository.GetAll(innerTables,filterPredicate);
            if (admins.Count() > 0)
            {
                return admins;
            }
            throw new DataNotFoundExcpetion("No admin Data found");
        }

        public async Task<Admin> GetById(int Id)
        {
        //    Expression<Func<Admin, bool>> filterPredicate = e => e.Status == true;
            var admin = await _repository.GetById(Id);
            if (admin != null)
            {
                return admin;
            }
            throw new DataNotFoundExcpetion("No admin Data found");
        }

        public async Task<bool> UpdateAdmin(Admin admin)
        {
            var adminToUpdate = await _repository.GetById(admin.AdminId);
            if (adminToUpdate != null)
            {
                return await _repository.Update(admin, admin.AdminId);
            }
            throw new DataNotFoundExcpetion("No admin Data found");
        }
    }
}
