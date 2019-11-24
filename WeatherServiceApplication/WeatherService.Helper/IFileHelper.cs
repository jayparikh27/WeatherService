using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.Helper
{
   public interface IFileHelper
    {
        bool SaveFile(string content, string cityId);
    }
}
