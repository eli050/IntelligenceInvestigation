using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceInvestigation.Entities
{
    public class AudioSensor: Sensor
    {
        public AudioSensor(string type): base(type)
        {

        }
        public override bool Activate(string SensorType)
        {
            return SensorType == Type;
        }
    }
}
