using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class HumiditySensor
    {
        public double GetHumidity()
        {
            Random r = new Random();
            int humidity = r.Next(0, 100);
            return humidity;
        }
    }
}
