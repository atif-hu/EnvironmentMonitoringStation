using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class HumiditySensor
    {
        public float GetHumidity()
        {
            Random r = new Random();
            float humidity = r.Next(0, 100);
            return humidity;
        }
    }
}
