using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities;

namespace IntelligenceInvestigation.Factory
{
    public static class SensorFactory
    {
        public static Sensor StartInstans(string type)
        {
            switch (type)
            {
                case "Audio":
                    return new AudioSensor(type);
                case "Thermal":
                    return null;
                case "Pulse":
                    return new PulseSensor(type);
                case "Motion":
                    return null;
                case "Magentic":
                    return null;
                case "Signal":
                    return null;
                case "Light":
                    return null;
                default:
                    return null;

            }
        }
    }
}
