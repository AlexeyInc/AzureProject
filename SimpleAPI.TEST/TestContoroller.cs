using System;
using Xunit;
using SimpleAPI.Controllers;

namespace SimpleAPI.TEST
{
    public class TestContoroller
    {
        WeatherForecastController weatherForecast = new WeatherForecastController();

        [Fact]
        public void Test1()
        {
            var result = weatherForecast.GetMultiplyNumber(9);
            Assert.Equal(18, result);
        }
    }
}
