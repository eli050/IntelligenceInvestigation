using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceInvestigation.Entities
{
    public class LightSensor:Sensor,IInformerT
    {
        public int AmountInformation = 1;
        public LightSensor(string type) : base(type)
        {

        }
        public override bool Activate(string SensorType)
        {
            return SensorType == Type;
        }
    }
}
