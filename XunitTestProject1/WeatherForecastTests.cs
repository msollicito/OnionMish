using Moq;
using OnionMish;
using System;
using Xunit;

namespace XunitTestProject1
{
    public class WeatherForecastTests
    {
        private MockRepository mockRepository;



        public WeatherForecastTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockRepository.VerifyAll();

        }

        private WeatherForecast CreateWeatherForecast()
        {
            return new WeatherForecast();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var weatherForecast = this.CreateWeatherForecast();

            // Act
            weatherForecast.TemperatureC = 25;
            var tempF = weatherForecast.TemperatureF;

            // Assert
            Assert.True(tempF == 76);
           
        }
    }
}
