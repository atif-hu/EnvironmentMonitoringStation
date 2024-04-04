using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class TemperatureSensor
    {
        public float GetTemperature()
        {
            Random r = new Random();
            float temperature = r.Next(-20, 39);
            return temperature;
        }
    }
}
