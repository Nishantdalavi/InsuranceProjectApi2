using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class CustomerService : ICustomerService
    {
        private IEntityRepository<Customer> _repository;

        public CustomerService(IEntityRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Customer>> GetAll(string[] innerTables)
        {
            Expression<Func<Customer, bool>> filterPredicate = e => e.Status ==true;
            var customers=await _repository.GetAll(innerTables,filterPredicate);
            if(customers.Count()>0)
            {
                return customers;
            }
            throw new DataNotFoundExcpetion("No Customer Data found");
        }
        public async Task AddCustomer(Customer customer)
        {
             await _repository.Insert(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var CustomerToDelete = await _repository.GetById(id);
            if (CustomerToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Customer Data Found To Delete");
        }

       

        public async Task<Customer> GetById(int Id)
        {
            var customer=await _repository.GetById(Id); 
            if(customer!=null)
            return customer;
            throw new DataNotFoundExcpetion("No Customer Data Found");
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var CustomerToUpdate = await _repository.GetById(customer.CustomerId);
            if(CustomerToUpdate!=null) 
                return await _repository.Update(customer,customer.CustomerId);
            throw new DataNotFoundExcpetion("No Customer Data Found To Update");
        }
    }
}
