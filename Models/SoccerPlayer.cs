namespace SoccerPlayerAPI.Models
{
	public class SoccerPlayer
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public Country? Country { get; set; }
	}
}
