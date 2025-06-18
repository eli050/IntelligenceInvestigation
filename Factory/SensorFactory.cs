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
                    return new SignalSensor(type);
                case "Light":
                    return new LightSensor(type);
                default:
                    return null;

            }
        }
    }
}
