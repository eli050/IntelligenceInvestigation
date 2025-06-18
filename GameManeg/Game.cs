using IntelligenceInvestigation.Entities;
using IntelligenceInvestigation.Factory;
using IntelligenceInvestigation.InterFaces;

namespace IntelligenceInvestigation.GameManeg
{
    public static class Game
    {
        static IranianAgent iranianAgent = AgentFactory.StartInstans();
        public static void StartGame()
        {
            Console.WriteLine("Hello and welcome to the game.\n" +
                $"You are investigating Agent {iranianAgent.Name}"
                );
            int won = 0;
            while (won != iranianAgent.LenTypes)
            {
                Console.WriteLine($"At what location would you like to insert the sensor?\n" +
                    $" (0-{iranianAgent.LenTypes - 1}) or anter -1 to add to the end");
                int index = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter the type of sensor you would like to insert: ");
                string type = Console.ReadLine()!;
                Sensor sensor = SensorFactory.StartInstans(type);
                if (sensor != null)
                {
                    if (iranianAgent.AddOrChangeSensor(index, sensor))
                    {
                        int temp = iranianAgent.NumOfMatch();
                        Console.WriteLine($"You scored {temp}/{iranianAgent.LenTypes} times");
                        won = temp;
                        _checkBrokens();
                        //_breakIfBroken(sensor);
                        _printInformation(sensor);
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
            Console.WriteLine("You won!!");
        }
        private static void _printInformation(Sensor sensor)
        {
            if(sensor is IInformerT informer && informer.FindOut)
            {
                List<string> Information = new List<string>()
                            {
                                $"The name of this agent is: {iranianAgent.Name}",
                                $"The rank of this Agent is:  {iranianAgent.Rank}",
                                $"The number of sensors this agent is sensitive to is:  {iranianAgent.LenTypes}"
                            };
                Random random = new Random();
                for (int i = 0; i < informer.AmountInformation; i++)
                {
                    int INX = random.Next(Information.Count);
                    Console.WriteLine(Information[INX]);

                }
            }
        }
        private static void _breakIfBroken(Sensor sensor)
        {
            if (sensor is IBreakabale breakabale && breakabale.IsBroken())
            {
                iranianAgent.ActivatSensor.Remove(sensor);
                Console.WriteLine(iranianAgent.ActivatSensor.Count);
            }
        }
        private static void _checkBrokens()
        {
            //foreach (Sensor sensor in iranianAgent.ActivatSensor)
            for (int i =0; i < iranianAgent.ActivatSensor.Count; i++)
            {
                if(iranianAgent.ActivatSensor[i] is IBreakabale breakabale)
                {
                    Console.WriteLine(breakabale.Count); 
                    _breakIfBroken(iranianAgent.ActivatSensor[i]);
                }
            }
        }
    }
}
