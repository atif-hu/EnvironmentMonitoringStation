using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class CO2EmissionsSensor
    {
        public double GetCO2Emissions()
        {
            Random r = new Random();
            int CO2 = r.Next(1, 100);
            return CO2;
        }
    }
}
