using System.ComponentModel.DataAnnotations;

namespace MonitoringStationAPI.Models
{
    public class HumidityData
    {
        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Humidity { get; set; }
    }
}
