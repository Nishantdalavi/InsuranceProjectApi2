using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemeDetailsController : ControllerBase
    {
        private ISchemeDetailsService _schemeDetailsService;
        public SchemeDetailsController(ISchemeDetailsService schemeDetailsService)
        {
            _schemeDetailsService = schemeDetailsService;
        }

        [HttpGet("GetAllSchemeDetails")]
        public async Task<IActionResult> GetSchemeDtails()
        {
            string[] innerTable = { };
            var schemeDetails = await _schemeDetailsService.GetAll(innerTable);
            var SchemeDetailDTOS = new List<SchemeDetailDTO>();
            foreach (var schemeDetail in schemeDetails)
            {
                SchemeDetailDTOS.Add(ConvertToSchemeDetailDTO(schemeDetail));
            }
            return Ok(SchemeDetailDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var schemeDetails = await _schemeDetailsService.GetById(Id);
            var schemeDetailDTO = ConvertToSchemeDetailDTO(schemeDetails);
            return Ok(schemeDetailDTO);
        }
        [HttpPost("AddSchemeDetail")]
        public async Task<IActionResult> AddSchemeDetail([FromBody] SchemeDetailDTO schemeDetailDTO)
        {
            var schemeDetail = ConvertToSchemeDetail(schemeDetailDTO);
            await _schemeDetailsService.AddSchemeDetail(schemeDetail);
            return Ok(schemeDetail);
        }
        [HttpPut("UpdateSchemeDetail")]
        public async Task<IActionResult> Update([FromBody] SchemeDetailDTO schemeDetailDTO)
        {
            var newSchemeDetail = ConvertToSchemeDetail(schemeDetailDTO);
            await _schemeDetailsService.UpdateSchemeDetail(newSchemeDetail);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteSchemeDetail/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _schemeDetailsService.DeleteSchemeDetail(id);

            return Ok("RemovedSuccessfully");


        }
        private SchemeDetails ConvertToSchemeDetail(SchemeDetailDTO schemeDetailDTO)
        {
            var schemDetail = new SchemeDetails()
            {
               
                DetailId= schemeDetailDTO.DetailId,
                Description= schemeDetailDTO.Description,
                MaxAmount= schemeDetailDTO.MaxAmount,
                MinAmount= schemeDetailDTO.MinAmount,
               // SchemeId= schemeDetailDTO.SchemeId,
                SchemeImage= schemeDetailDTO.SchemeImage,
                Status= schemeDetailDTO.Status,
                MinAge= schemeDetailDTO.MinAge,
                MaxAge= schemeDetailDTO.MaxAge,
                

            };
            return schemDetail;

        }
        private SchemeDetailDTO ConvertToSchemeDetailDTO(SchemeDetails schemeDetails)
        {
            var schemDetailDTO = new SchemeDetailDTO()
            {

                DetailId = schemeDetails.DetailId,
                Description = schemeDetails.Description,
                MaxAmount = schemeDetails.MaxAmount,
                MinAmount = schemeDetails.MinAmount,
               // SchemeId = schemeDetails.SchemeId,
                SchemeImage = schemeDetails.SchemeImage,
                Status = schemeDetails.Status,
                MaxAge= schemeDetails.MaxAge,
                MinAge= schemeDetails.MinAge,
            };
            return schemDetailDTO;

        }
    }
}
