using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceSchemeController : ControllerBase
    {
        private IInsuranceSchemesService _insuranceSchemesService;
        public InsuranceSchemeController(IInsuranceSchemesService insuranceSchemesService)
        {
            _insuranceSchemesService = insuranceSchemesService;
        }
        [HttpGet("GetAllSchemes")]
        public async Task<IActionResult> GetSchemes()
        {
            string[] innerTable = {  "SchemeDetails" };
            var Schemes = await _insuranceSchemesService.GetAll(innerTable);
            var SchemeDTOS = new List<InsuranceSchemeDTO>();
            foreach (var scheme in Schemes)
            {
                SchemeDTOS.Add(ConvertToSchemeDTO(scheme));
            }
            return Ok(SchemeDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var Scheme = await _insuranceSchemesService.GetById(Id);
            var SchemeDTO = ConvertToSchemeDTO(Scheme);
            return Ok(SchemeDTO);
        }
        [HttpPost("AddScheme")]
        public async Task<IActionResult> AddScheme([FromBody] InsuranceSchemeDTO schemeDTO)
        {
            var Scheme = ConvertToScheme(schemeDTO);
            await _insuranceSchemesService.AddScheme(Scheme);
            return Ok(Scheme);
        }
        [HttpPut("UpdateScheme")]
        public async Task<IActionResult> Update([FromBody] InsuranceSchemeDTO schemeDTO)
        {
            var NewScheme = ConvertToScheme(schemeDTO);
            await _insuranceSchemesService.UpdateScheme(NewScheme);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteScheme/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _insuranceSchemesService.DeleteScheme(id);

            return Ok("Removed Successfully");


        }
        private InsuranceScheme ConvertToScheme(InsuranceSchemeDTO schemeDTO)
        {
            var Scheme = new InsuranceScheme()
            {
                SchemeId = schemeDTO.SchemeId,
                SchemeName = schemeDTO.SchemeName,
                Status = schemeDTO.Status,
                Plans = new List<InsurancePlan>(),
                Policies = new List<Policy>(),
                
            };
            return Scheme;

        }
        private InsuranceSchemeDTO ConvertToSchemeDTO(InsuranceScheme scheme)
        {
            var SchemeDTO = new InsuranceSchemeDTO()
            {
                SchemeId = scheme.SchemeId,
                SchemeName = scheme.SchemeName,
                Status = scheme.Status,
                PlansCount = scheme.Plans != null ? scheme.Plans.Count : 0,
                PoliciesCount = scheme.Policies != null ? scheme.Policies.Count() : 0,
            };
            return SchemeDTO;
        }
    }
}
