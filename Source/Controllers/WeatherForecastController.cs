using Microsoft.AspNetCore.Mvc;
using Source.CosmosDbService;
using Source.Models;

namespace Source.Controllers
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
        private readonly CosmosDbConnection _cosmosDbConnection;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CosmosDbConnection cosmosDbConnection)
        {
            _logger = logger;
            _cosmosDbConnection = cosmosDbConnection;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<User> Post()
        {
            return await _cosmosDbConnection.AddUserAsync();
        }
    }
}
