using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities
{
    public class IranianAgent
    {
        public List<Sensor> ActivatSensor = new List<Sensor>();
        public string Name { get; set; }
        private string _rank;
        public string Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                string[] ranks = new string[] { "Foot Soldier", "Squad Leader", "Senior Commander", "Organization Leader" };
                if (ranks.Contains(value))
                {
                    _rank = value;
                }
            }
        }
        public int LenTypes { get; set; }
        public List<string> Weakness;
        public IranianAgent(string name, string rank, List<string> weakness)
        {
            Name = name;
            _rank = rank;
            switch (rank)
            {
                case "Foot Soldier":
                    LenTypes = 2;
                    break;
                case "Squad Leader":
                    LenTypes = 4;
                    break;
                case "Senior Commander":
                    LenTypes = 6;
                    break;
                case "Organization Leader":
                    LenTypes = 8;
                    break;
            }
            Weakness = weakness;
        }
        public int NumOfMatch()
        {
            int HitStamp = 0;
            List<string> types = new List<string>(Weakness);
            foreach (Sensor sensor in ActivatSensor)
            {
                for(int i = 0; i < types.Count; i++)
                {
                    if (sensor.Activate(types[i]))
                    {
                        _informerAndMatch(sensor);
                        HitStamp++;
                        types.RemoveAt(i);
                        break;
                    } 
                }
                _breakTimer(sensor);
            }
            return HitStamp;
        }
        public bool AddOrChangeSensor(int index , Sensor val)
        {
            if (index == -1 && ActivatSensor.Count < LenTypes)
            {
                ActivatSensor.Add(val);
                return true;
            }
            else if (index < LenTypes && ActivatSensor.Count > index && index >= 0)
            {
                ActivatSensor[index] = val;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void _informerAndMatch(Sensor sensor)
        {
            if (sensor is IInformerT informer)
            {
                informer.FindOut = true;
            }
        }
        private  void _breakTimer(Sensor sensor)
        {
            if (sensor is IBreakabale breakabale)
            {
                breakabale.Count++;
            }
        }

    }
}
