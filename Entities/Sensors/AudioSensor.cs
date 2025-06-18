using System;
using System.Collections.Generic;
using System.Linq;
namespace IntelligenceInvestigation.Entities.Sensors
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
