
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherService.Business;

namespace WeatherService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherServiceController : ControllerBase
    {
        private readonly IWeatherCityBusiness _iWeatherCityBusiness;

        public WeatherServiceController(IWeatherCityBusiness weatherCityBusiness)
        {
            _iWeatherCityBusiness = weatherCityBusiness;
        }

        [HttpPost]
        public IActionResult GetWeatherDetails(IFormFile file)
        {
            try
            {
                bool result = false;
                if (file != null && file.Length > 0 && file.FileName.Contains(".txt"))
                    result = _iWeatherCityBusiness.GetWeatherDetails(file);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}