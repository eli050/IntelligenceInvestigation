using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities.Sensors;

namespace IntelligenceInvestigation.InterFaces
{
    public interface IAttacker
    {
        public int WhenToAttack { get; }
        public int Counter { get; set; }
        public bool IfAttack();
        public void ToAttack(List<Sensor> sensors);
    }
}
