using IntelligenceInvestigation.Entities.Agents;
using IntelligenceInvestigation.Entities.Players;
using IntelligenceInvestigation.Entities.Sensors;
using IntelligenceInvestigation.Factory;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.GameManeg
{
    public static class Game
    {
        static IranianAgent iranianAgent; 
        public static void StartGame()
        {
            int HighestStage = 2;
            Console.WriteLine("Hello and welcome to the game: Discover the agent.\n");
            Console.WriteLine("Enter yore name: ");
            string Name = Console.ReadLine()!;
            Console.WriteLine("Enter a username: ");
            string UserName = Console.ReadLine()!;
            Player player = new Player(Name, UserName);
            iranianAgent = AgentFactory.StartInstans(player.Stage);
            while (player.Stage <= HighestStage)
            {
                Console.WriteLine();
                Console.WriteLine($"You are in stage {player.Stage} of the game.\n");
                Console.WriteLine($"You are investigating Agent {iranianAgent.Name}\n\n");
    
                int won = 0;
                while (won != iranianAgent.LenTypes)
                {
                    Console.WriteLine($"Please enter the position where you’d like to add a sensor—use an index\n" +
                        $" from 0 through {iranianAgent.LenTypes - 1} (inclusive) to replace an existing value, or -1 to append it to the end.");
                    int index = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Enter the type of sensor you would like to insert: ");
                    string type = Console.ReadLine()!;
                    Sensor sensor = SensorFactory.StartInstans(type);
                    if (sensor != null)
                    {
                        if (iranianAgent.AddOrChangeSensor(index, sensor))
                        {
                            int temp = iranianAgent.NumOfMatch();
                            Console.WriteLine($"You scored {temp}/{iranianAgent.LenTypes} times\n");
                            Console.WriteLine("The attached sensors are:\n");
                            foreach(Sensor sen in iranianAgent.ActivatSensor)
                            {
                                Console.Write($"{sen.Type} ");
                            }
                            Console.WriteLine();
                            won = temp;
                            _deleteBrokens();
                            _printInformation(sensor);
                            _timerAttack();
                        }
                        else
                        {
                            Console.WriteLine("invalid character or index out of range, please enter again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no such sensor.");
                    }

                }
                Console.WriteLine($"You have defeated Agent {iranianAgent.Name} and you move on to the next level.");
                player.Stage++;
                iranianAgent = AgentFactory.StartInstans(player.Stage);

            }
            Console.WriteLine("There is no next step, you won!!!\n" +
                "Wubba Lubba dub-dub");   
        }
        private static void _printInformation(Sensor sensor)
        {
            if (sensor is IInformerT informer && informer.FindOut)
            {
                List<string> Information = new List<string>()
                            {
                                $"The name of this agent is: {iranianAgent.Name}",
                                $"The rank of this Agent is:  {iranianAgent.Rank}",
                                $"The number of sensors this agent is sensitive to is:  {iranianAgent.LenTypes}"
                            };
                Random random = new Random();
                for (int _ = 0; _ < informer.AmountInformation; _++)
                {
                    int INX = random.Next(Information.Count);
                    Console.WriteLine(Information[INX]);
                    Information.RemoveAt(INX);

                }
            }
        }
        private static void _breakIfBroken(Sensor sensor)
        {
            if (sensor is IBreakabale breakabale && breakabale.IsBroken())
            {
                iranianAgent.ActivatSensor.Remove(sensor);
                Console.WriteLine("one sensor was deleted\n");
            }
        }
        private static void _deleteBrokens()
        { 
            for (int i = iranianAgent.ActivatSensor.Count - 1; i >= 0; i--)
            {
                if (iranianAgent.ActivatSensor[i] is IBreakabale breakabale)
                {
                    _breakIfBroken(iranianAgent.ActivatSensor[i]);
                }
            }
        }
        private static void _timerAttack()
        {
            if (iranianAgent is IAttacker attacker)
            {
                attacker.Counter++;
                if (attacker.IfAttack())
                {
                    attacker.ToAttack(iranianAgent.ActivatSensor);
                }
            }

        }
    }
}
