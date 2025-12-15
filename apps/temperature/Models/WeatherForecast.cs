using System.Text.Json.Serialization;

namespace Temperature.Models
{
    public class WeatherForecast
    {
        public double Value { get; set; }

        public string Unit { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        [JsonPropertyName("sensor_id")]
        public string SensorID { get; set; }

        [JsonPropertyName("sensor_type")]
        public string SensorType { get; set; }

        public string Description { get; set; }
    }
}
