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
        public static Sensor[] ActivatSensor = new Sensor[2];
        public string Name { get; set; }
        public string Rank { get; set; }
        public string[] SensorTypes;
        public IranianAgent(string name, string rank, string[] sensorTypes)
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

    }
}
