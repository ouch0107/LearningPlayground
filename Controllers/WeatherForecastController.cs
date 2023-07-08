using LearningPlayground.Models;
using LearningPlayground.Models.RandomModel;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRandomModel _randomModel;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IRandomModel randomModel
            )
        {
            _logger = logger;
            _randomModel = randomModel;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Value1 = _randomModel.Value1,
                Value2 = _randomModel.Value2
            })
            .ToArray();
        }
    }
}