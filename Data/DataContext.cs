using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<SoccerPlayer> SoccerPlayers { get; set; }
		public DbSet<Country> Country { get; set; }
	}
}
