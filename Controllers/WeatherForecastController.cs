using LearningPlayground.Models;
using LearningPlayground.Models.RandomModel;
using LearningPlayground.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRandomModel _randomModel;
        private readonly IProductRepository _productRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IRandomModel randomModel,
            IProductRepository productRepository
            )
        {
            _logger = logger;
            _randomModel = randomModel;
            _productRepository = productRepository;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
    }
}