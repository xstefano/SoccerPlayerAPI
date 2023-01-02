using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayerAPI.Models;
using SoccerPlayerAPI.Services;

namespace SoccerPlayerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CountriesController : ControllerBase
	{
		private readonly ICountryService _countryService;

		public CountriesController(ICountryService countryService)
		{
			_countryService = countryService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Country>>> GetContries()
		{
			return await _countryService.GetCountries();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Country>>> GetCountriesById(int id)
		{
			var country = await _countryService.GetCountryById(id);

			if (country is null)
				return NotFound("Country not found.");

			return Ok(country);
		}

		[HttpPost]
		public async Task<ActionResult<List<Country>>> AddCountry(Country country)
		{
			var result = await _countryService.AddCountry(country);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<Country>>> UpdateCountry(int id, Country request)
		{
			var result = await _countryService.UpdateCountry(id, request);

			if (result is null)
				return NotFound("Country not found.");

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Country>>> DeleteCountry(int id)
		{
			var result = await _countryService.DeleteCountry(id);

			if (result is null)
				return NotFound("Country not found.");

			return Ok(result);
		}
	}
}
