using System;
using IntelligenceInvestigation.Entities.Agents;

namespace IntelligenceInvestigation.Factory
{
    static public class AgentFactory
    {
        static public IranianAgent StartInstans(int stage)
        {
            switch (stage)
            {
                case 1:
                    string name = GetName();
                    string[] weakness = GetWeakness(2);
                    return new FootSoldir(name, weakness);
                case 2:
                    return null;
                case 3:
                    return null;
                case 4:
                    return null;
                default:
                    return null;
            }
        }
        private static string[] GetWeakness(int amount)
        {
            Random random = new Random();
            List<string> Types = new List<string>()
            {
                "Audio",
                //"Thermal",
                "Pulse",
                //"Motion",
                //"Magentic",
                "Signal",
                "Light"
            };
            List<string> weakness = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                string type = Types[random.Next(Types.Count)];
                weakness.Add(type);
            }
            return weakness.ToArray();
        }
        private static string GetName()
        {
            Random random = new Random();

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
            return name;
        }
        
    }
}
