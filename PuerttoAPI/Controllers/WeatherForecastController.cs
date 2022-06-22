using Core.Puertto;
using Microsoft.AspNetCore.Mvc;
using PuerttoAPI.Interfaces;
using PuerttoAPI.Services;

namespace PuerttoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("puertto/example")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IExample _example;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IExample example)
        {
            _logger = logger;
            _example = example;    
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("save")]
        public async Task SaveFarmCapacityAsync([FromBody] Example example)
        {
            await _example.SaveDataExample(example).ConfigureAwait(false);
        }

        [HttpGet("all")]
        public async Task<List<Example>> allData()
        {
           return await _example.All().ConfigureAwait(true);
        }
    }
}