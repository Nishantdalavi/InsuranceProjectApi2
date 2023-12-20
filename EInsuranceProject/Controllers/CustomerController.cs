using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            string[] innerTable = { "Documents","Agents","Policies","Complaints"};
            var customers = await _customerService.GetAll(innerTable);
            var customerDTOS=new List<CustomerDTO>();
            foreach (var customer in customers) 
            {
                customerDTOS.Add(ConvertToCustomerDTO(customer));
            }
            return Ok(customerDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var customer = await _customerService.GetById(Id);
            var customerDTO = ConvertToCustomerDTO(customer);
            return Ok(customerDTO);
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            var customer = ConvertToCustomer(customerDTO);
            await _customerService.AddCustomer(customer);
            return Ok(customer);
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Update([FromBody] CustomerDTO customerDTO)
        {
            var newCustoemr = ConvertToCustomer(customerDTO);
            await _customerService.UpdateCustomer(newCustoemr);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteCustomer/{id:int}")]
        public async Task<IActionResult> Delete( int id)
        {
            await _customerService.DeleteCustomer(id);

            return Ok("RemovedSuccessfully");


        }
        private Customer ConvertToCustomer(CustomerDTO customerDTO)
        {
            var customer = new Customer()
            {
                CustomerId = customerDTO.CustomerId,
                CustomerFirstName = customerDTO.CustomerFirstName,
                CustomerLastName = customerDTO.CustomerLastName,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                State = State.Rajasthan,
                City = customerDTO.City,
                Nominee = customerDTO.Nominee,
                NomineeRelation = customerDTO.NomineeRelation,
                Status = customerDTO.Status,
                Address = customerDTO.Address,
                Agents = new List<Agent>(),
                Documents=new List<Document>(),
                Policies=new List<Policy>() ,
                Queries = new List<Complaint>() ,

            };
            return customer;

        }
        private CustomerDTO ConvertToCustomerDTO(Customer customer)
        {
            var customerDTO = new CustomerDTO()
            {
                CustomerId = customer.CustomerId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                State = customer.State,
                City = customer.City,
                Status = customer.Status,
                Nominee = customer.Nominee,
                NomineeRelation = customer.NomineeRelation,
                AgentsCount = customer.Agents != null? customer.Agents.Count() : 0,
                DocumentsCount = customer.Documents != null?customer.Documents.Count() : 0,
                PoliciesCount = customer.Policies != null?customer.Policies.Count() : 0,
                QueryCount = customer.Queries != null?customer.Queries.Count() : 0,
            };
            return customerDTO;
        }
    }
}
