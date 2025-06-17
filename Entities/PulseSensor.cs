using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.Entities
{
    public class PulseSensor: Sensor, IBreakabale
    {
        private int count = 0;
        public PulseSensor(string type) : base(type)
        {

        }
        public override bool Activate(string type)
        {
            count++;
            return type == Type;
        }
        public bool IsBroken()
        {
            return count == 3;
        }
    }
}
