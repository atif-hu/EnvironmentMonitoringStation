using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class RainfallSensor
    {
        public double GetRainfall()
        {
            Random r = new Random();
            int rainfall = r.Next(0, 40);
            return rainfall;
        }
    }
}
