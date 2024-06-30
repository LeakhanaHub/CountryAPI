using CountryAPI.Model;
using CountryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController:ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            try
            {
                var result = await _countryService.GetCountryByNameAsync(name);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
        [HttpPost("GetCountryByArea")]
        public async Task<IActionResult> GetCountryByArea(CountryArea param)
        {
            try
            {
                var result = await _countryService.GetCountryByAreaAsync(param);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
    
}
