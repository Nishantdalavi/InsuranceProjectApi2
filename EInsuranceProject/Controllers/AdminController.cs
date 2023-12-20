using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
       
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
            
        }


        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAdmins()
        {
            string[] innerTable = { };
            var admins = await _adminService.GetAll(innerTable);
            var adminDTOS = new List<AdminDTO>();
            foreach (var admin in admins)
            {
                adminDTOS.Add(ConvertToAdminDTO(admin));
            }
            return Ok(adminDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var customer = await _adminService.GetById(Id);
            var customerDTO = ConvertToAdminDTO(customer);
            return Ok(customerDTO);
        }
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDTO adminDTO)
        {
            var Admin = ConvertToAdmin(adminDTO);
            await _adminService.AddAdmin(Admin);
            return Ok(Admin);
        }
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> Update([FromBody] AdminDTO adminDTO)
        {
            var newAdmin = ConvertToAdmin(adminDTO);
            await _adminService.UpdateAdmin(newAdmin);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteAdmin/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.DeleteAdmin(id);

            return Ok("RemovedSuccessfully");


        }
        
        private Admin ConvertToAdmin(AdminDTO adminDTO)
        {
            var Admin = new Admin()
            {
                AdminId=adminDTO.AdminId,
                AdminFirstName=adminDTO.AdminFirstName,
                AdminLastName=adminDTO.AdminLastName,
                Status=adminDTO.Status,
            };
            return Admin;

        }
        private AdminDTO ConvertToAdminDTO(Admin admin)
        {
            var adminDTO = new AdminDTO()
            {
                AdminId = admin.AdminId,
                AdminFirstName = admin.AdminFirstName,
                AdminLastName = admin.AdminLastName,
                Status=admin.Status,


            };
            return adminDTO;
        }
    }
}
