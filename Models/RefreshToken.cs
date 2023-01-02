namespace SoccerPlayerAPI.Models
{
	public class RefreshToken
	{
		public string Token { get; set; } = string.Empty;
		public DateTime Created { get; set; } = DateTime.MinValue;
		public DateTime Expires { get; set; }
	}
}
