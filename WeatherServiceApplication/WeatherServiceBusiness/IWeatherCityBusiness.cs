using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherServiceBusiness
{
   public interface IWeatherCityBusiness
    {
        void GetWeatherDetails(IFormFile file);
    }
}
