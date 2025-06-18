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
            //Count++;
            return type == Type;
        }
        public bool IsBroken()
        {
            //Console.WriteLine(Count);
            return Count == 3;
        }
    }
}
