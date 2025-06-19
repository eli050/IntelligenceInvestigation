using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities.Sensors
{
    public class PulseSensor: Sensor, IBreakabale
    {
        public int Count { get; set; }
        public PulseSensor(string type) : base(type)
        {
            Count = 0;
        }
        public override bool Activate(string type)
        {
            return type == Type;
        }
        public bool IsBroken()
        {
            return Count == 3;
        }
    }
}
