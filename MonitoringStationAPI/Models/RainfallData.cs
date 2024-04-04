using System.ComponentModel.DataAnnotations;

namespace MonitoringStationAPI.Models
{
    public class RainfallData
    {
        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Rainfall { get; set; }
    }
}
