using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;

namespace EInsuranceProject.Services
{
    public class UserService : IUserService
    {
        private IEntityRepository<User> _repository;    
        public UserService(IEntityRepository<User>repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAll(string[] innerTables)
        {
             var users= await _repository.GetAll(innerTables);
             if(users!=null)
                return users;
            throw new DataNotFoundExcpetion("No User Data found");

        }
        public async Task<User>GetById(int Id)
        {
            var user= await _repository.GetById(Id);
            if(user!=null) 
                return user;
            throw new DataNotFoundExcpetion("No User Data found");

        }
        public async Task AddUser(User user)
        {
           await _repository.Insert(user);
        }
        public async Task<bool> UpdateUser(User user)
        {
            var UserToUpdate= await _repository.GetById(user.UserId);
            if(UserToUpdate!=null)
            {
                return await _repository.Update(user, user.UserId);
            }
            throw new DataNotFoundExcpetion("No User found to update");
        }

        public async Task<bool> DeleteUser(int id)
        {
            var UserToDelete = await _repository.GetById(id);
            if( UserToDelete!=null )
            {
                return  await _repository.Delete(id);

            }
            throw new DataNotFoundExcpetion("No User found to Delete");
        }
    }
}
