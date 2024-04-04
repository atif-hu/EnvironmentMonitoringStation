using System.ComponentModel.DataAnnotations;

namespace MonitoringStationAPI.Models
{
    public class AirPollutionData
    {
        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public double AirPollution { get; set; }
    }
}
