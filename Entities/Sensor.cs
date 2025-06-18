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
