using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using WeatherService.Helper;

namespace WeatherServiceBusiness
{
    public class WeatherCityBusiness : IWeatherCityBusiness
    {
        private readonly IHttpHelper _iHttpHelper;
        private readonly IFileHelper _iFileHelper;
        private const string OPENWEATHERMAP_URL = "https://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}";
        public WeatherCityBusiness(IHttpHelper httpHelper, IFileHelper fileHelper)
        {
            _iHttpHelper = httpHelper;
            _iFileHelper = fileHelper;
        }
        public void GetWeatherDetails(IFormFile file)
        {
            List<string> cityIds = new List<string>();
            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();

                        var cityid = Regex.Match(line, @"\d+").Value;
                        if (!string.IsNullOrEmpty(cityid))
                            cityIds.Add(cityid);
                    }
                }
                foreach (var cityId in cityIds)
                {
                    var response = _iHttpHelper.ExecuteGet(string.Format(OPENWEATHERMAP_URL, cityId, "aa69195559bd4f88d79f9aadeb77a8f6"));
                    if (response != null && response.Content != null)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        _iFileHelper.SaveFile(content, cityId);
                    }
                }


            }
        }

        private void SaveCityDetails(List<string> cityIds)
        {

        }


    }
}
