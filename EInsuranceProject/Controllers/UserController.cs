using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      private IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult>GetUsers()
        {
            string[] innerTable = {};
            var users=await _userService.GetAll(innerTable);
            return Ok(users);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult>GetByID([FromQuery]int Id)
        {
            
                var user = await _userService.GetById(Id);

                return Ok(user); 
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUser(user);
            return Ok(user);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            await _userService.UpdateUser(user);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete([FromQuery]int Id)
        {
             await _userService.DeleteUser(Id);
           
                return Ok("RemovedSuccessfully");
           
            
        }


    }
}
