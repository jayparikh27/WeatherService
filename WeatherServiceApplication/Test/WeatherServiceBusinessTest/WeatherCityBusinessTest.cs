using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Moq;
using WeatherService.Business;
using System.IO;
using WeatherService.Helper;
using System.Net;
using System.Net.Http;

namespace WeatherServiceBusinessTest
{
    public class WeatherCityBusinessTest
    {
        private readonly Mock<IHttpHelper> _iHttpHelper;
        private readonly Mock<IFileHelper> _iFileHelper;

        public WeatherCityBusinessTest()
        {
            _iHttpHelper = new Mock<IHttpHelper>();
            _iFileHelper = new Mock<IFileHelper>();
        }
        [Fact]
        public void GetWeatherDetails()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "2643741=City of London";

            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            _iHttpHelper.Setup(x => x.ExecuteGet(It.IsAny<string>())).Returns(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("Test") });
            _iFileHelper.Setup(x => x.SaveFile(It.IsAny<string>(), It.IsAny<string>()));
            WeatherCityBusiness weatherCityBusiness = new WeatherCityBusiness(_iHttpHelper.Object, _iFileHelper.Object);
            bool result = weatherCityBusiness.GetWeatherDetails(fileMock.Object);
            Assert.True(result);




        }
    }
}
