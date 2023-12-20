using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEntityRepository<Employee> _repository;
        public EmployeeService(IEntityRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task AddEmployee(Employee employee)
        {
           await _repository.Insert(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var EmployeeToDelete = await _repository.GetById(id);
            if (EmployeeToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Employee Data found");
        }

        public async Task<IEnumerable<Employee>> GetAll(string[] innerTables)
        {
            Expression<Func<Employee, bool>> filterPredicate = e => e.Status == true;
            var Employees = await _repository.GetAll(innerTables,filterPredicate);
            if (Employees.Count() > 0)
            {
                return Employees;
            }
            throw new DataNotFoundExcpetion("No Employee Data found");
        }

        public async Task<Employee> GetById(int Id)
        {
            var Employee = await _repository.GetById(Id);
            if (Employee != null)
            {
                return Employee;
            }
            throw new DataNotFoundExcpetion("No Employee Data found");
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var EmployeeToUpdate = await _repository.GetById(employee.EmployeeId);
            if (EmployeeToUpdate != null)
            {
                return await _repository.Update(employee, employee.EmployeeId);
            }
            throw new DataNotFoundExcpetion("No Policy Data found");
        }
    }
}

