using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("number/{num}")]
        public int GetMultiplyNumber(int num)
        {
            return num * 2;
        }
         
        [HttpGet]
        [Route("coupleNumbers")]
        public int? GetComplexObj([FromQuery] MyNumbers myNumbers)
        {
            var result = myNumbers.NumOne + myNumbers.NumTwo;
            return result;
        }

        [HttpGet]
        [Route("coupleNumbersFromBody")]
        public int? GetComplexObjFromBody(MyNumbers myNumbers)
        {
            var result = myNumbers.NumOne + myNumbers.NumTwo;
            return result;
        }

        [HttpGet]
        [Route("~/")]
        public JsonResult GetMyPersonalData()
        {
            return new JsonResult(
                new { Name = "Alexey", Age = 23, Hobbies = "IT, Chill out" }
                );
        }
    }
}
