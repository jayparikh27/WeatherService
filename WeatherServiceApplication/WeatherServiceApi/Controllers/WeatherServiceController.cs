using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherServiceBusiness;

namespace WeatherServiceApi.Controllers
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
        public IActionResult GetWeatherDetailsAsync(IFormFile file)
        {
            _iWeatherCityBusiness.GetWeatherDetails(file);


            return Ok();
        }
    }
}