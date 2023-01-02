using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPI.Data;
using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Services
{
	public class SoccerPlayerService : ISoccerPlayerService
	{
		private readonly DataContext _context;

		public SoccerPlayerService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<SoccerPlayer>> GetSoccerPlayers()
		{
			return await _context.SoccerPlayers
									.Include(c => c.Country)
									.ToListAsync();
		}

		public async Task<SoccerPlayer?> GetSoccerPlayerById(int id)
		{
			var soccerPlayer = await _context.SoccerPlayers.FindAsync(id);

			if (soccerPlayer is null)
				return null;

			return soccerPlayer;
		}

		public async Task<List<SoccerPlayer>> AddSoccerPlayer(SoccerPlayer player)
		{
			 _context.SoccerPlayers.Add(player);
			await _context.SaveChangesAsync();

			return await _context.SoccerPlayers
									.Include(c => c.Country)
									.ToListAsync();
		}

		public async Task<List<SoccerPlayer>?> UpdateSoccerPlayer(int id, SoccerPlayer request)
		{
			var soccerPlayer = await _context.SoccerPlayers.FindAsync(id);

			if (soccerPlayer is null)
				return null;

			soccerPlayer.Name = request.Name;
			soccerPlayer.FirstName = request.FirstName;
			soccerPlayer.LastName = request.LastName;
			soccerPlayer.Country = request.Country;

			await _context.SaveChangesAsync();
			return await _context.SoccerPlayers
									.Include(c => c.Country)
									.ToListAsync();

		}

		public async Task<List<SoccerPlayer>?> DeleteSoccerPlayer(int id)
		{
			var soccerPlayer = await _context.SoccerPlayers.FindAsync(id);
			
			if (soccerPlayer is null)
				return null;

			_context.SoccerPlayers.Remove(soccerPlayer);

			await _context.SaveChangesAsync();
			return await _context.SoccerPlayers
									.Include(c => c.Country)
									.ToListAsync();
		}
	}
}
