using Microsoft.AspNetCore.Mvc;
using ILogger = DigitalBallotPlatform.Shared.Logger.ILogger;

namespace DigitalBallotPlatform.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ILogger Logger { get; }

        public WeatherForecastController(ILogger logger)
        {
            Logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = Enumerable.Range(1, 5);
            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(rng.Average())),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            Logger.LogInformation("User {UserId} is creating a new car with model {Model}", User.Identity?.Name!);

            return (IEnumerable<WeatherForecast>)forecast;
        }
    }
}
