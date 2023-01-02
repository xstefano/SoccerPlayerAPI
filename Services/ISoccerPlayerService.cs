using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Services
{
	public interface ISoccerPlayerService
	{
		Task<List<SoccerPlayer>> GetSoccerPlayers();
		Task<SoccerPlayer?> GetSoccerPlayerById(int id);
		Task<List<SoccerPlayer>> AddSoccerPlayer(SoccerPlayer player);
		Task<List<SoccerPlayer>?> UpdateSoccerPlayer(int id, SoccerPlayer request);
		Task<List<SoccerPlayer>?> DeleteSoccerPlayer(int id);
	}
}
