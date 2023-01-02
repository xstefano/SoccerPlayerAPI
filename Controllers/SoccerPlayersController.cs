using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SoccerPlayersController : ControllerBase
	{
		private readonly ISoccerPlayerService _soccerPlayerService;

		public SoccerPlayersController(ISoccerPlayerService soccerPlayerService)
		{
			_soccerPlayerService = soccerPlayerService;
		}

		[HttpGet]
		public async Task<ActionResult<List<SoccerPlayer>>> GetSoccerPlayers()
		{
			return await _soccerPlayerService.GetSoccerPlayers();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<SoccerPlayer>>> GetSoccerPlayerById(int id)
		{
			var soccerPlayer = await _soccerPlayerService.GetSoccerPlayerById(id);

			if (soccerPlayer is null)
				return NotFound("Soccer Player not found.");

			return Ok(soccerPlayer);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<List<SoccerPlayer>>> AddSoccerPlayer(SoccerPlayer soccerPlayer)
		{
			var result = await _soccerPlayerService.AddSoccerPlayer(soccerPlayer);
			return Ok(result);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<List<SoccerPlayer>>> UpdateSoccerPlayer(int id, SoccerPlayer request)
		{
			var result = await _soccerPlayerService.UpdateSoccerPlayer(id, request);

			if (result is null)
				return NotFound("Soccer Player not found.");

			return Ok(result);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]	
		public async Task<ActionResult<List<SoccerPlayer>>> DeleteSoccerPlayer(int id)
		{
			var result = await _soccerPlayerService.DeleteSoccerPlayer(id);

			if (result is null)
				return NotFound("Soccer Player not found.");

			return Ok(result);
		}
	}
}
