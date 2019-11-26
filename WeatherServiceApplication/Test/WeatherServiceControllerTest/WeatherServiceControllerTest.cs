using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Moq;
using WeatherService.Business;
using System.IO;
using WeatherService.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WeatherServiceControllerTest
{
    public class WeatherServiceControllerTest
    {
        readonly Mock<IWeatherCityBusiness> iWeatherCityBusiness;
        public WeatherServiceControllerTest()
        {
            iWeatherCityBusiness = new Mock<IWeatherCityBusiness>();
        }
        [Fact]
        public void GetWeatherDetails()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "2643741=City of London";

            var fileName = "test.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            iWeatherCityBusiness.Setup(x => x.GetWeatherDetails(fileMock.Object)).Returns(true);
            WeatherServiceController weatherServiceController = new WeatherServiceController(iWeatherCityBusiness.Object);
            var result = weatherServiceController.GetWeatherDetails(fileMock.Object);

            Assert.True((bool)((ObjectResult)result).Value);
        }

        [Fact]
        public void GetWeatherDetails_ThrowsError()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "2643741=City of London";

            var fileName = "test.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            iWeatherCityBusiness.Setup(x => x.GetWeatherDetails(fileMock.Object)).Throws( new Exception("GetWeatherDetails error") );
            WeatherServiceController weatherServiceController = new WeatherServiceController(iWeatherCityBusiness.Object);
            var result = weatherServiceController.GetWeatherDetails(fileMock.Object);

            Assert.Equal("GetWeatherDetails error", ((Exception)((ObjectResult)result).Value).Message);
        }
    }
}
