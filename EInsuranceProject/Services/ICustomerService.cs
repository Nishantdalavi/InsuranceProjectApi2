using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAll(string[] innerTables);
        public Task<Customer> GetById(int Id);
        public Task AddCustomer(Customer customer);
        public Task<bool> UpdateCustomer(Customer customer);
        public Task<bool> DeleteCustomer(int id);
    }
}
