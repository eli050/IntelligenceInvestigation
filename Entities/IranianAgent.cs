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
        public string Rank { get; set; }
        public List<string> SensorTypes;
        public IranianAgent(string name, string rank, List<string> sensorTypes)
        {
            Name = name;
            Rank = rank;
            SensorTypes = sensorTypes;
        }
        public int Adjustment()
        {
            int HitStamp = 0;
            foreach (Sensor sensor in ActivatSensor)
            {
                foreach(string type in SensorTypes)
                {
                    if (sensor.Activate(type))
                    {
                        HitStamp++;
                        break;
                    }
                }
            }
            return HitStamp;
        }
        public bool AddOrChangeSensor(int index , Sensor val)
        {
            if (index == -1 && index < ActivatSensor.Count )
            {
                ActivatSensor.Add(val);
                return true;
            }
            else if (index < SensorTypes.Count && ActivatSensor.Count > index && index > 0)
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
