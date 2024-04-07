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
    public class HumiditySensorController : ControllerBase // Changed from Controller to ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HumiditySensorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<float>> GetHumdity()
        {
            var humiditySensor = new HumiditySensor(); // Create instance of HumiditySensor
            float humidityValue = humiditySensor.GetHumidity();

            bool triggerWarning = false;        //constant for humidity as normal threshold is N/A

            var humidityData = new HumidityData
            {
                SensorId = 2,
                Timestamp = DateTime.UtcNow,
                Humidity = humidityValue,
                TriggerThresholdWarning = triggerWarning
            };

            // Serialize temperature data to JSON
            var jsonContent = JsonSerializer.Serialize(humidityData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Send POST request to Monitoring Station API
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7051/"); // Replace with your Monitoring Station API base URL

                var response = await httpClient.PostAsync("/api/temperature", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(humidityData);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to send humidity data to Monitoring Station API.");
                }
            }

        }

        public class HumidityData
        {
            public int Id { get; set; }
            public int SensorId { get; set; }
            public DateTime Timestamp { get; set; }
            public float Humidity { get; set; }
            public bool TriggerThresholdWarning { get; set; }

        }
    }
}
