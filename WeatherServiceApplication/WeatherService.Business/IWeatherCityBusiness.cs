using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.Business
{
   public interface IWeatherCityBusiness
    {
        bool GetWeatherDetails(IFormFile file);
    }
}
