using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
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
                if(sensor != null)
                {
                    if (iranianAgent.AddOrChangeSensor(index, sensor))
                    {
                        int temp = iranianAgent.Adjustment();
                        Console.WriteLine($"You scored {temp}/{iranianAgent.LenTypes} times");
                        won = temp;
                        if (sensor is IInformerT informer)
                        {
                            Dictionary<string, Object> Information = new Dictionary<string, object>()
                            {
                                ["The name of this agent is: "] = iranianAgent.Name,
                                ["The rank of this Agent is: "] = iranianAgent.Rank,
                                //["The number of sensors this agent is sensitive to is: "] = iranianAgent.LenTypes
                            };
                            int count = 0;
                            foreach (string inform in Information.Keys)
                            {
                                
                                Console.WriteLine($"{inform}{Information[inform]}");
                                count++;
                                if (count > informer.AmountInformation)
                                {
                                    break;
                                }
                            }
                        }
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
    }
}
