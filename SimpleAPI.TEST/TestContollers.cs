using System;
using Xunit;
using SimpleAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpleAPI.TEST
{
    public class TestContollers
    {
        private readonly ILogger<NumberController> _logger;

        private readonly NumberController _numbersController;

        public TestContollers()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var _logger = factory.CreateLogger<NumberController>();

            _numbersController = new NumberController();

            _logger.LogInformation("End of the MyCtor <- LogInformation"); 

        }

        [Fact]
        public void Test1()
        {
            var result = _numbersController.GetMultiplyNumber(9);
            Assert.Equal(18, result.Value); 

            // _logger.LogDebug("Test is finish"); // here _logger is null
        }
    }
}
