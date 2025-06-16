using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> SensorTypes;
        public IranianAgent(string name, string rank, List<string> sensorTypes)
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
            SensorTypes = sensorTypes;
        }
        public int Adjustment()
        {
            int HitStamp = 0;
            List<string> types = new List<string>();
            types.AddRange(SensorTypes);
            foreach (Sensor sensor in ActivatSensor)
            {
                for(int i = 0; i < types.Count; i++)
                {
                    if (sensor.Activate(types[i]))
                    {
                        HitStamp++;
                        types.RemoveAt(i);
                        break;
                    }
                    if (sensor.broken)
                    {
                        //HitStamp--;
                        ActivatSensor.Remove(sensor);  
                    }
                }
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

    }
}
