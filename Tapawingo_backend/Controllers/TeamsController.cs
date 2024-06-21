using Microsoft.AspNetCore.Mvc;
using Tapawingo_backend.Dtos;
using Tapawingo_backend.Models;
using Tapawingo_backend.Services;

namespace Tapawingo_backend.Controllers
{
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamsController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("/editions/{editionId}/teams")]
        public async Task<IActionResult> GetTeamsOnEdition(int editionId)
        {
            var response =  await _teamService.GetTeamsOnEdition(editionId);
            return Ok(response);
        }

        [HttpGet("/editions/{editionId}/teams/{teamId}")]
        public async Task<IActionResult> GetTeamOnEditionAsync(int editionId, int teamId)
        {
            var response = await _teamService.GetTeamOnEditionAsync(editionId, teamId);
            return Ok(response);
        }

        [HttpPost("/editions/{editionId}/teams")]
        public async Task<IActionResult> CreateTeamOnEdition(int editionId, CreateTeamDto model)
        {
            var response = await _teamService.CreateTeamOnEditionAsync(editionId, model);
            return Ok(response);
        }

        [HttpPatch("/editions/{editionId}/teams/{teamId}")]
        public async Task<IActionResult> UpdateTeamOnEdition(int editionId, int teamId, [FromBody] UpdateTeamDto model)
        {
            var response = await _teamService.UpdateTeamOnEditionAsync(editionId, teamId, model);
            return Ok(response);
        }

        [HttpDelete("/editions/{editionId}/teams/{teamId}")]
        public async Task<IActionResult> DeleteTeamOnEditionAsync(int editionId, int teamId)
        {
            return await _teamService.DeleteTeamOnEditionAsync(editionId, teamId);
        }
    }
}
