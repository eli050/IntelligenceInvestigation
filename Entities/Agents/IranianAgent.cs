using IntelligenceInvestigation.Entities.Sensors;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities.Agents
{
    public abstract class IranianAgent
    {
        public List<Sensor> ActivatSensor = new List<Sensor>();
        public string Name;
        public string Rank;
        public int LenTypes;
        public string[] Weakness;
        public IranianAgent(string name, string[] weakness)
        {
            Name = name;
            Weakness = weakness;
        }
        public abstract int NumOfMatch();

        public abstract bool AddOrChangeSensor(int index, Sensor val);
    }
}
