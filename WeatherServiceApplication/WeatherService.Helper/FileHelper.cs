using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherService.Helper
{
    public class FileHelper : IFileHelper
    {
        public bool SaveFile(string content, string cityId)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo di = Directory.CreateDirectory(string.Format(currentDirectory+ "/App_Data/{0}",cityId));
                var appDataPath = Path.Combine(di.FullName,string.Format("{0:yyyy-MM-dd}__{1}.txt",DateTime.Now,cityId));
                var saveFile = File.Create(appDataPath);
                using (var streamWriter = new StreamWriter(saveFile))
                {
                    streamWriter.WriteLine(content);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
