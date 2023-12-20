using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private IPolicyService _policyService;
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("GetAllPolicies")]
        public async Task<IActionResult> GetPolicies()
        {
            string[] innerTable = { "Payments", "Claims" };
            var policies = await _policyService.GetAll(innerTable);
            var policyDTOS = new List<PolicyDTO>();
            foreach (var policy in policies)
            {
                policyDTOS.Add(ConvertToPolicyDTO(policy));
            }
            return Ok(policyDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var policy = await _policyService.GetById(Id);
            var policyDTO = ConvertToPolicyDTO(policy);
            return Ok(policyDTO);
        }
        [HttpPost("AddPolicy")]
        public async Task<IActionResult> AddPolicy([FromBody] PolicyDTO policyDTO)
        {
            var policy = ConvertToPolicy(policyDTO);
            await _policyService.AddPolicy(policy);
            return Ok(policy);
        }
        [HttpPut("UpdatePolicy")]
        public async Task<IActionResult> Update([FromBody] PolicyDTO policyDTO)
        {
            var newPolicy = ConvertToPolicy(policyDTO);
            await _policyService.UpdatePolicy(newPolicy);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeletePolicy/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _policyService.DeletePolicy(id);

            return Ok("Removed Successfully");


        }
        private Policy ConvertToPolicy(PolicyDTO policyDTO)
        {
            var policy = new Policy()
            {
                PolicyNo = policyDTO.PolicyNo,
                Premium = policyDTO.Premium,
                PremiumMode = Mode.Year,
                IssueDate = DateTime.Now,
                MaturityDate = DateTime.Now,
                SumAssured = policyDTO.SumAssured,
                Status = policyDTO.Status,
                Customers = new List<Customer>(),
                Payments=new List<Payment>(),
                
            };
            return policy;

        }
        private PolicyDTO ConvertToPolicyDTO(Policy Policy)
        {
            var policyDTO = new PolicyDTO()
            {
               PolicyNo=Policy.PolicyNo,
               Premium=Policy.Premium,
               SumAssured=Policy.SumAssured,
               Status = Policy.Status,
               IssueDate=Policy.IssueDate,
               MaturityDate=Policy.MaturityDate,
               PremiumMode=Policy.PremiumMode,
               PaymentCount=Policy.Payments!=null?Policy.Payments.Count():0,
             

            };
            return policyDTO;
        }
    }
}
