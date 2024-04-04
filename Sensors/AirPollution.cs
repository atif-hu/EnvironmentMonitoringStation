using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class AirPollutionSensor
    {
        public double GetAirPollution()
        {
            Random r = new Random();
            int air_pollution = r.Next(1, 10);
            return air_pollution;
        }
    }
}
