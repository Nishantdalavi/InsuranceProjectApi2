using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            string[] innerTable = { };
            var Employees = await _employeeService.GetAll(innerTable);
            var EmployeeDTOS = new List<EmployeeDTO>();
            foreach (var employee in Employees)
            {
                EmployeeDTOS.Add(ConvertToEmployeeDTO(employee));
            }
            return Ok(EmployeeDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var customer = await _employeeService.GetById(Id);
            var customerDTO = ConvertToEmployeeDTO(customer);
            return Ok(customerDTO);
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var customer = ConvertToEmployee(employeeDTO);
            await _employeeService.AddEmployee(customer);
            return Ok(customer);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> Update([FromBody] EmployeeDTO employeeDTO)
        {
            var newEmployee = ConvertToEmployee(employeeDTO);
            await _employeeService.UpdateEmployee(newEmployee);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteEmployee/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);

            return Ok("RemovedSuccessfully");


        }
        private Employee ConvertToEmployee(EmployeeDTO employeeDTO)
        {
            var Employee = new Employee()
            {
                EmployeeId= employeeDTO.EmployeeId,
                EmployeeFirstName= employeeDTO.EmployeeFirstName,
                EmployeeLastName= employeeDTO.EmployeeLastName,
                Email= employeeDTO.Email,
                Phone= employeeDTO.Phone,
                Salary= employeeDTO.Salary,
                Status= employeeDTO.Status,
               

            };
            return Employee;

        }
        private EmployeeDTO ConvertToEmployeeDTO(Employee employee)
        {
            var EmployeeDTO = new EmployeeDTO()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary=employee.Salary,
                Status = employee.Status,
               

            };
            return EmployeeDTO;
        }
    }
}
