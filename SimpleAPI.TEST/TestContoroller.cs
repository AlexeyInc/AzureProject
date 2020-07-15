using System;
using Xunit;
using SimpleAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpleAPI.TEST
{
    public class TestContoroller
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly WeatherForecastController _weatherForecast;

        public TestContoroller()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var _logger = factory.CreateLogger<WeatherForecastController>();

            _weatherForecast = new WeatherForecastController(_logger);

            _logger.LogInformation("End of the MyCtor <- LogInformation"); 

        }

        [Fact]
        public void Test1()
        {
            var result = _weatherForecast.GetMultiplyNumber(9);
            Assert.Equal(18, result); 

            // _logger.LogDebug("Test is finish"); // here _logger is null
        }
    }
}
