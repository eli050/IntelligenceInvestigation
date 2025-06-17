using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities
{
    public class SignalSensor:Sensor,IInformerT
    {
        public int AmountInformation { get; set; }
        public SignalSensor(string type) : base(type)
        {
            AmountInformation = 1;
        }
        public override bool Activate(string SensorType)
        {
            return SensorType == Type;
        }
    }
}
