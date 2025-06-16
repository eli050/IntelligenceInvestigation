using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceInvestigation.Entities
{
    public class PulseSensor: Sensor
    {
        public bool broken = false;
        private int count = 0;
        public PulseSensor(string type) : base(type)
        {

        }
        public override bool Activate(string type)
        {
            count++;
            broken = IsBroken();
            return type == Type;
        }
        private bool IsBroken()
        {
            return count == 3;
        }
    }
}
