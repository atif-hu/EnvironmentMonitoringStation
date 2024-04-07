using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Sensors;

namespace SensorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureSensorController : ControllerBase // Changed from Controller to ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TemperatureSensorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<float>> GetTemperature()
        {
            var temperatureSensor = new TemperatureSensor(); // Create instance of TemperatureSensor
            float temperatureValue = temperatureSensor.GetTemperature();

            bool triggerWarning = false;

            if(temperatureValue < -9 || temperatureValue > 30)
            {
                triggerWarning = true;
            }

            var temperatureData = new TemperatureData
            {
                SensorId = 1,
                Timestamp = DateTime.UtcNow,
                Temperature = temperatureValue,
                TriggerThresholdWarning = triggerWarning
            };

            // Serialize temperature data to JSON
            var jsonContent = JsonSerializer.Serialize(temperatureData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Send POST request to Monitoring Station API
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7051/"); // Replace with your Monitoring Station API base URL

                var response = await httpClient.PostAsync("/api/temperature", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(temperatureData);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to send temperature data to Monitoring Station API.");
                }
            }

        }

        public class TemperatureData
        {
            public int Id { get; set; }
            public int SensorId { get; set; }
            public DateTime Timestamp { get; set; }
            public float Temperature { get; set; }
            public bool TriggerThresholdWarning { get; set; }

        }
    }
}
