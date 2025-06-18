using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities
{
    public class LightSensor:Sensor,IInformerT
    {
        public bool FindOut { get; set; }
        public int AmountInformation { get; set; }
        public LightSensor(string type) : base(type)
        {
            FindOut = false;
            AmountInformation = 2;
        }
        public override bool Activate(string SensorType)
        {
            return SensorType == Type;
        }
    }
}
