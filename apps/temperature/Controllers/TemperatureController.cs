using Microsoft.AspNetCore.Mvc;
using Temperature.Models;

namespace Temperature.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {

        private readonly ILogger<TemperatureController> _logger;
        private readonly SmartHomeDb _db;
        public TemperatureController(SmartHomeDb db, ILogger<TemperatureController> logger)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet()]
        public WeatherForecast Get(string location)
        {
            var tempC = Random.Shared.Next(-20, 55);
            _logger.LogInformation($"location: {location}; tempC: {tempC}");

            var sensors = _db.Sensors.ToArray();
            var sensor = sensors.FirstOrDefault(q=>string.Equals(q.Location, location, StringComparison.CurrentCultureIgnoreCase));

            if (sensor == null)
            {
                _logger.LogError($"Sensor not found for {location}");
                return new WeatherForecast();
            }

            return new WeatherForecast()
            {
                Description = "",
                Location    = sensor.Location,
                SensorID    = sensor.Id,
                SensorType  = sensor.Type,
                Status      = sensor.Status,
                Timestamp   = DateTimeOffset.UtcNow.UtcDateTime,
                Unit        = sensor.Unit,
                Value       = tempC
            };
        }
    }
}
