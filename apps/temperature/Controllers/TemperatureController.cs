using Microsoft.AspNetCore.Mvc;

namespace Temperature.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ILogger<TemperatureController> logger)
        {
            _logger = logger;
        }
        [HttpGet()]
        public int Get(string location)
        {
            var tempC = Random.Shared.Next(-20, 55);
            _logger.LogInformation($"location: {location}; tempC: {tempC}");

            return tempC;
        }

        //[HttpGet()]
        //public IEnumerable<WeatherForecast> Get(string location)
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
