using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePlansController : ControllerBase
    {
        private IInsurancePlanService _insurancePlanService;

        public InsurancePlansController(IInsurancePlanService insurancePlanService) 
        {
            _insurancePlanService = insurancePlanService;
        }

        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> GetInsurancePlans()
        {
            string[] innerTable = {};
            var Plans = await _insurancePlanService.GetAll(innerTable);
            var PlanDTOS = new List<InsurancePlanDTO>();
            foreach (var plan in Plans)
            {
                PlanDTOS.Add(ConvertToPlanDTO(plan));
            }
            return Ok(PlanDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var Plan = await _insurancePlanService.GetById(Id);
            var PlanDTO = ConvertToPlanDTO(Plan);
            return Ok(PlanDTO);
        }
        [HttpPost("AddPlan")]
        public async Task<IActionResult> AddInsurancPlan([FromBody] InsurancePlanDTO planDTO)
        {
            var plan = ConvertToInsurancePlan(planDTO);
            await _insurancePlanService.AddInsurancePlan(plan);
            return Ok(plan);
        }
        [HttpPut("UpdatePlan")]
        public async Task<IActionResult> Update([FromBody] InsurancePlanDTO planDTO)
        {
            var newPlan = ConvertToInsurancePlan(planDTO);
            await _insurancePlanService.UpdatePlan(newPlan);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeletePlan/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _insurancePlanService.DeletePlan(id);

            return Ok("RemovedSuccessfully");


        }

        private InsurancePlan ConvertToInsurancePlan(InsurancePlanDTO insurancePlanDTO)
        {
            var insurancePlan = new InsurancePlan()
            {
                PlanId = insurancePlanDTO.PlanId,
                PlanName = insurancePlanDTO.PlanName,

                Schemes = new List<InsuranceScheme>(),
               
                Status=insurancePlanDTO.Status,
            };
            return insurancePlan;

        }
        private InsurancePlanDTO ConvertToPlanDTO(InsurancePlan insurancePlan)
        {
            var PlanDTO = new InsurancePlanDTO()
            {
                PlanId = insurancePlan.PlanId,
                PlanName = insurancePlan.PlanName,
                Status = insurancePlan.Status,
                SchemesCount = insurancePlan.Schemes != null ? insurancePlan.Schemes.Count() : 0,
            };
            return PlanDTO;
            
        }
    }
}
