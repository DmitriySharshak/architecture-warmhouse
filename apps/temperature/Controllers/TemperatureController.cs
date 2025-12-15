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
            

            var sensorID = "";
            switch (location)
            {
                case "Living Room":
                    sensorID = "1";
                    break;
                case "Bedroom":
                    sensorID = "2";
                    break;
                case "Kitchen":
                    sensorID = "3";
                    break;
                default:
                    sensorID = "0";
                    break;
            }

            _logger.LogInformation($"sensorID: {sensorID}, location: {location}, value: {tempC}");

            //var sensors = _db.Sensors.ToArray();
            //var sensor = sensors.FirstOrDefault(q=>string.Equals(q.Location, location, StringComparison.CurrentCultureIgnoreCase));

            //if (sensor == null)
            //{
            //    _logger.LogError($"Sensor not found for {location}");
            //   return new WeatherForecast();
            //}

            return new WeatherForecast()
            {
                Location    = location,
                SensorID    = sensorID,
                Timestamp   = DateTimeOffset.UtcNow.UtcDateTime,
                Value       = tempC
            };
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {
            var tempC = Random.Shared.Next(-20, 55);

            var location = "";
            switch (id)
            {
                case 1:
                    location = "Living Room";
                    break;
                case 2:
                    location = "Bedroom";
                    break;
                case 3:
                    location = "Kitchen";
                    break;
                default:
                    location = "Unknown";
                    break;
            }

            _logger.LogInformation($"sensorID: {id}, location: {location}, value: {tempC}");
            
            return new WeatherForecast()
            {
                Location  = location,
                SensorID  = id.ToString(),
                Timestamp = DateTimeOffset.UtcNow.UtcDateTime,
                Value     = tempC
            };
        }
    }
}
