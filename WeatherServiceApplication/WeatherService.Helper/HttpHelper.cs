using System;
using System.Net.Http;

namespace WeatherService.Helper
{
    public class HttpHelper: IHttpHelper
    {
        public HttpResponseMessage ExecuteGet(string url)
        {
            try
            {
                HttpResponseMessage responseMessage = null;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);
                using (var httpClient = new HttpClient())
                {
                    var responseTask = httpClient.SendAsync(request);
                    if (responseTask != null)
                        responseMessage = responseTask.Result;

                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
