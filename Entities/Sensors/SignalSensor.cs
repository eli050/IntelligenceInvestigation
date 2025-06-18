using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities.Sensors
{
    public class SignalSensor:Sensor,IInformerT
    {
        public bool FindOut { get; set; }
        public int AmountInformation { get; set; }
        public SignalSensor(string type) : base(type)
        {
            FindOut = false;
            AmountInformation = 1;
        }
        public override bool Activate(string SensorType)
        {
            return SensorType == Type;
        }
    }
}
