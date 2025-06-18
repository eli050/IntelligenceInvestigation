using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceInvestigation.Entities.Players
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Stage;
        public Player(string name, string nickName, int stage = 0)
        {
            Name = name;
            NickName = nickName;
            Stage = stage;
        }
        public Player(int id, string name,
                      string nickName,
                      int stage = 0)
            : this(name, nickName, stage)
        {
            Id = id;
        }
    }
}
