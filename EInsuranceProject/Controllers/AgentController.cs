using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAgentService _agentService;
        public AgentController(IAgentService agentService) 
        {
            _agentService = agentService;
        }
        [HttpGet("GetAllAgents")]
        public async Task<IActionResult>GetAgents()
        {
            string[] innerTable = {"Customers"};
            var agents=await _agentService.GetAll(innerTable);
            var agentDTOS=new List<AgentDTO>();
            foreach (var agent in agents)
            {
                agentDTOS.Add(ConvertToAgentDTO(agent));
                

            }
            return Ok(agentDTOS);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var agent = await _agentService.GetById(Id);
            var agentDTO = ConvertToAgentDTO(agent);
            return Ok(agentDTO);
        }
        [HttpPost("AddAgent")]
        public async Task<IActionResult> AddAgent([FromBody] AgentDTO agentDTO)
        {
            var agent = ConvertToAgent(agentDTO);
            await _agentService.AddAgent(agent);
            return Ok(agent);
        }
        [HttpPut("UpdateAgent")]
        public async Task<IActionResult> Update([FromBody] AgentDTO agentDTO)
        {
            var newAgent = ConvertToAgent(agentDTO);
            await _agentService.UpdateAgent(newAgent);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteAgent/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _agentService.DeleteAgent(id);

            return Ok("Removed Successfully");


        }

        private Agent ConvertToAgent(AgentDTO agentDTO)
        {
            var agent = new Agent()
            {
                AgentId = agentDTO.AgentId,
                AgentFirstName = agentDTO.AgentFirstName,
                AgentLastName = agentDTO.AgentLastName,
                Email = agentDTO.Email,
                Phone = agentDTO.Phone,
                Status = agentDTO.Status,
              
                CommissionEarned = agentDTO.CommissionEarned,
                Customers = new List<Customer>(),
                Qualification=agentDTO.Qualification,

            
            };
            return agent;

        }
        private AgentDTO ConvertToAgentDTO(Agent agent)
        {
            var agentDTO = new AgentDTO()
            {
                AgentId = agent.AgentId,
                AgentFirstName = agent.AgentFirstName,
                AgentLastName = agent.AgentLastName,
                Email = agent.Email,
                Phone = agent.Phone,
               
                Status = agent.Status,

             
                CommissionEarned= agent.CommissionEarned,
                Qualification= agent.Qualification,
                CustomersCount=agent.Customers!=null?agent.Customers.Count():0,

            };
            return agentDTO;
        }
    }
}
