using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WeatherService.Helper
{
   public interface IHttpHelper
    {
        HttpResponseMessage ExecuteGet(string url);
    }
}
