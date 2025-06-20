﻿
using IntelligenceInvestigation.Entities.Sensors;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities.Agents
{
    public class FootSoldir:IranianAgent
    {
   
        public FootSoldir(string name, string[] weakness):base(name,weakness)
        {
            Rank = "Foot Soldir";
            LenTypes = 2;
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
