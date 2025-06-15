using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities;

namespace IntelligenceInvestigation.GameManeg
{
    public static class Game
    {
        static IranianAgent iranianAgent = new IranianAgent("muhamad", "junior",new List<string>{"basic","basic"});
        public static void StartGame()
        {
            Console.WriteLine("Hello and welcome to the game.\n" +
                $"You are investigating Agent {iranianAgent.Name}"
                );
            int won = 0;
            while (won != iranianAgent.SensorTypes.Count)
            {
                Console.WriteLine("At what location would you like to insert the sensor? (0-1)");
                int index = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter the type of sensor you would like to insert:\n");
                string type = Console.ReadLine()!;
                Sensor sensor = new Sensor(type);
                if (iranianAgent.AddOrChangeSensor(index, sensor))
                {
                    int temp = iranianAgent.Adjustment();
                    Console.WriteLine($"You scored {temp}/{iranianAgent.SensorTypes.Count} times");
                    won = temp;
                }
            }
            Console.WriteLine("You won!!");

        }
    }
}
