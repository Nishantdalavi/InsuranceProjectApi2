using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private IComplaintService _complaintService;
        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }
        [HttpGet("GetAllCompalints")]
        public async Task<IActionResult> GetCompalints()
        {
            string[] innerTable = { };
            var complaints = await _complaintService.GetAll(innerTable);
            var ComplaintDTOS = new List<ComplaintDTO>();
            foreach (var complaint in complaints)
            {
                ComplaintDTOS.Add(ConvertToComplaintDTO(complaint));
            }
            return Ok(ComplaintDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var Complaint = await _complaintService.GetById(Id);
            var ComplaintDTO = ConvertToComplaintDTO(Complaint);
            return Ok(ComplaintDTO);
        }
        [HttpPost("AddComplaint")]
        public async Task<IActionResult> AddCompalint([FromBody] ComplaintDTO complaintDTO)
        {
            var Complaint = ConvertToComplaint(complaintDTO);
            await _complaintService.AddComplaint(Complaint);
            return Ok(Complaint);
        }
        [HttpPut("UpdateComplaint")]
        public async Task<IActionResult> Update([FromBody] ComplaintDTO complaintDTO)
        {
            var newComplaint = ConvertToComplaint(complaintDTO);
            await _complaintService.UpdateComplaint(newComplaint);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteComplaint/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _complaintService.DeleteComplaint(id);

            return Ok("Removed Successfully");


        }
        private Complaint ConvertToComplaint(ComplaintDTO ComplaintDTO)
        {
            var Complaint = new Complaint()
            {
                ComplaintId = ComplaintDTO.ComplaintId,
                ComplaintName = ComplaintDTO.ComplaintName,
                ComplaintMessage = ComplaintDTO.ComplaintMessage,
                DateOfComplaint = ComplaintDTO.DateOfComplaint,
                Status = ComplaintDTO.Status,

            };
            return Complaint;

        }
        private ComplaintDTO ConvertToComplaintDTO(Complaint complaint)
        {
            var ComplaintDTO = new ComplaintDTO()
            {

                ComplaintId = complaint.ComplaintId,
                ComplaintName = complaint.ComplaintName,
                ComplaintMessage = complaint.ComplaintMessage,
                DateOfComplaint = complaint.DateOfComplaint,
                Status = complaint.Status,
            };
            return ComplaintDTO;
        }
    }
}
