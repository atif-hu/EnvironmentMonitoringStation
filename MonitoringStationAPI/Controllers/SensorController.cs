using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringStationAPI.Database;
using MonitoringStationAPI.Models;

namespace SensorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SensorController : ControllerBase
    {       
        private readonly MonitoringStationDbContext _context;

        //public SensorController(MonitoringStationDbContext context)
        //{
        //    _context = context;
        //}

        public SensorController()
        {
            _context = DatabaseContextSingleton.Instance.GetDbContext();
        }

        [HttpPost("AddSensor")]
        public IActionResult AddSensor([FromBody] Sensor sensor)
        {
            if (sensor == null)
            {
                return BadRequest("Sensor data is null.");
            }

            try
            {
                // Add the new sensor entity to the DbContext
                _context.Sensor.Add(sensor);

                // Save changes to the database
                _context.SaveChanges();

                return Ok("Sensor added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

