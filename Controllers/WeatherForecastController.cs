using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherClient client;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(WeatherClient client, ILogger<WeatherForecastController> logger)
        {
            this.client = client;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("it is working");
        }

        [HttpGet]
        [Route("{city}")]
        // GET weather/London
        public async Task<WeatherForecast> Get(string city)
        {
            var forecast = await client.GetCurrentWeatherAsync(city);
            return new WeatherForecast{
                Summary = forecast.weather[0].description,
                TemperatureC = (int)forecast.main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime
            };
        }
    }
}
