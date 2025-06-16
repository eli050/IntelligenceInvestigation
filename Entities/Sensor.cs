using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceInvestigation.Entities
{
    public abstract class Sensor
    {
        public string Type { get; set; }
        public Sensor(string type)
        {
            Type = type;
        }
        public abstract bool Activate(string SensorType);
        
    }
}
