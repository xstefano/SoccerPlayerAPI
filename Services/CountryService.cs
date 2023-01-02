using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPI.Data;
using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Services
{
	public class CountryService : ICountryService
	{
		private readonly DataContext _context;

		public CountryService(DataContext context)
		{
			_context = context;
		}



		public async Task<List<Country>> GetCountries()
		{
			return await _context.Country.ToListAsync();
		}

		public async Task<Country?> GetCountryById(int id)
		{
			var country = await _context.Country.FindAsync(id);

			if (country is null)
				return null;

			return country;
		}

		public async Task<List<Country>> AddCountry(Country country)
		{
			_context.Country.Add(country);
			await _context.SaveChangesAsync();

			return await _context.Country.ToListAsync();
		}

		public async Task<List<Country>?> UpdateCountry(int id, Country request)
		{
			var country = await _context.Country.FindAsync(id);

			if (country is null)
				return null;

			country.Name = request.Name;

			await _context.SaveChangesAsync();
			return await _context.Country.ToListAsync();
		}

		public async Task<List<Country>?> DeleteCountry(int id)
		{
			var country = await _context.Country.FindAsync(id);

			if (country is null)
				return null;

			_context.Country.Remove(country);

			await _context.SaveChangesAsync();
			return await _context.Country.ToListAsync();
		}


	}
}
