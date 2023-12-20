using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAll(string[] innerTables);
        public Task<Employee> GetById(int Id);
        public Task AddEmployee(Employee employee);
        public Task<bool> UpdateEmployee(Employee employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
