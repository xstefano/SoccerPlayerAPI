using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Services
{
	public interface ICountryService
	{
		Task<List<Country>> GetCountries();
		Task<Country?> GetCountryById(int id);
		Task<List<Country>> AddCountry(Country country);
		Task<List<Country>?> UpdateCountry(int id, Country request);
		Task<List<Country>?> DeleteCountry(int id);
	}
}
