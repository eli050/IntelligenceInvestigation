using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities.Sensors;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities.Agents
{
    public class SquadLeader:IranianAgent,IAttacker
    {
        public int WhenToAttack { get; private set; }
        public int Counter { get; set; }
        public SquadLeader(string name, string[] weakness) : base(name, weakness)
        {
            WhenToAttack = 3;
            Rank = "Squad Leader";
            LenTypes = 4;
            Name = name;
            Weakness = weakness;
        }
        public override int NumOfMatch()
        {
            int HitStamp = 0;
            List<string> types = new List<string>(Weakness);
            foreach (Sensor sensor in ActivatSensor)
            {
                for (int i = 0; i < types.Count; i++)
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
        public override bool AddOrChangeSensor(int index, Sensor val)
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
        public bool IfAttack()
        {
            return Counter == WhenToAttack;
        }
        public void ToAttack(List<Sensor> sensors)
        {
            Random random = new Random();
            sensors.RemoveAt(random.Next(sensors.Count));
            Counter = 0;
            Console.WriteLine("one sensor was deleted\n");
        }
        private void _informerAndMatch(Sensor sensor)
        {
            if (sensor is IInformerT informer)
            {
                informer.FindOut = true;
            }
        }
        private void _breakTimer(Sensor sensor)
        {
            if (sensor is IBreakabale breakabale)
            {
                breakabale.Count++;
            }
        }

    }
}

