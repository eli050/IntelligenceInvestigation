using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities;

namespace IntelligenceInvestigation.Factory
{
    static public class AgentFactory
    {
        static public IranianAgent StartInstans()
        {
            Random random = new Random();
            List<string> Ranks = new List<string>()
            {
                "Foot Soldier",
                "Squad Leader",
                "Senior Commander",
                "Organization Leader"

            };
            List<string> Types = new List<string>()
            {
                "Audio",
                "Thermal",
                "Pulse",
                "Motion",
                "Magentic",
                "Signal",
                "Light"
            };
            List<string> iranianNames = new List<string>
            {
                "Ali",
                "Reza",
                "Hossein",
                "Mohammad",
                "Saeed",
                "Amir",
                "Mehdi",
                "Hamid",
                "Kaveh",
                "Nima",
                "Shahin",
                "Bahram",
                "Farhad",
                "Arash",
                "Omid",
                "Yousef",
                "Navid",
                "Behnam",
                "Peyman",
                "Sina",
                "Shervin",
                "Babak",
                "Kian",
                "Ehsan",
                "Javad",
                "Ladan",
                "Shirin",
                "Mitra",
                "Negin",
                "Roxana",
                "Parisa",
                "Niloofar",
                "Elham",
                "Mahsa",
                "Sahar",
                "Leila",
                "Zahra",
                "Maryam",
                "Fatemeh",
                "Nasrin",
                "Azadeh",
                "Yasaman",
                "Hanieh",
                "Setareh",
                "Samira",
                "Fereshteh",
                "Arezoo",
                "Taraneh",
                "Ghazal",
                "Sepideh"
            };
            string name = iranianNames[random.Next(iranianNames.Count)];
            string rank = Ranks[random.Next(Ranks.Count)];
            List<string> TypesOfSensor = new List<string>();
            IranianAgent iranianAgent = new IranianAgent(name, rank, TypesOfSensor);
            for (int i =0; i< iranianAgent.LenTypes; i++)
            {
                string type = Types[random.Next(Types.Count)];
                iranianAgent.SensorTypes.Add(type);
            }
            return iranianAgent;
        }
        
    }
}
