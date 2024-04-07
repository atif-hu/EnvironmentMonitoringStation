// TemperatureController.cs
using Microsoft.AspNetCore.Mvc;
using MonitoringStationAPI.Database;
using MonitoringStationAPI.Models;

namespace MonitoringStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly MonitoringStationDbContext _dbContext;

        //public TemperatureController(MonitoringStationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public TemperatureController()
        {
            _dbContext = DatabaseContextSingleton.Instance.GetDbContext();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TemperatureData>> GetTemperatureData()
        {
            var temperatureData = _dbContext.TemperatureData.ToList();
            return Ok(temperatureData);
        }

        [HttpPost]
        public IActionResult PostTemperatureData([FromBody] TemperatureData temperatureData)
        {
            if (temperatureData == null)
            {
                return BadRequest("Invalid temperature data");
            }

            // Save temperature data to the database
            _dbContext.TemperatureData.Add(temperatureData);
            _dbContext.SaveChanges();

            return Ok(temperatureData);
        }
    }
}
