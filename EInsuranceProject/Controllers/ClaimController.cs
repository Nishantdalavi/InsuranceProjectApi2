using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
      private  IClaimService _claimService;
        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }
        [HttpGet("GetAllClaim")]
        public async Task<IActionResult> GetClaims()
        {
            string[] innerTable = { "Policies" };
            var Claims = await _claimService.GetAll(innerTable);
            var ClaimDTOS = new List<ClaimDTO>();
            foreach (var claim in Claims)
            {
                ClaimDTOS.Add(ConvertToClaimDTO(claim));
            }
            return Ok(ClaimDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var Claim = await _claimService.GetById(Id);
            var ClaimDTO = ConvertToClaimDTO(Claim);
            return Ok(ClaimDTO);
        }
        [HttpPost("AddClaim")]
        public async Task<IActionResult> AddClaim([FromBody] ClaimDTO claimDTO)
        {
            var Claim = ConvertToClaim(claimDTO);
            await _claimService.AddClaim(Claim);
            return Ok(Claim);
        }
        [HttpPut("UpdateClaim")]
        public async Task<IActionResult> Update([FromBody] ClaimDTO claimDTO)
        {
            var newClaim = ConvertToClaim(claimDTO);
            await _claimService.UpdateClaim(newClaim);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteClaim/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _claimService.DeleteClaim(id);

            return Ok("Removed Successfully");


        }
        private Claim ConvertToClaim(ClaimDTO claimDTO)
        {
            var Claim = new Claim()
            {
                ClaimId = claimDTO.ClaimId,
                ClaimAmount = claimDTO.ClaimAmount,
                ClaimDate = claimDTO.ClaimDate,
                BankAccountNo = claimDTO.BankAccountNo,
                BankIFSCCode = claimDTO.BankIFSCCode,
                Status = claimDTO.Status,
                Policies = new List<Policy>(),


            };
            return Claim;

        }
        private ClaimDTO ConvertToClaimDTO(Claim claim)
        {
            var ClaimDTO = new ClaimDTO()
            {
                ClaimId = claim.ClaimId,
                ClaimAmount = claim.ClaimAmount,
                ClaimDate = claim.ClaimDate,
                BankAccountNo = claim.BankAccountNo,
                BankIFSCCode = claim.BankIFSCCode,
                Status = claim.Status,
                PoliciesCount = claim.Policies!=null? claim.Policies.Count():0,

            };
            return ClaimDTO;
        }
    }
}
