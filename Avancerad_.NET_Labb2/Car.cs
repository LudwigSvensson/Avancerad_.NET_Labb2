using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Avancerad_.NET_Labb2
{
    internal class Car
    {
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public bool HasFinished { get; set; }

      
        public Car (string model, string colour, int speed) 
        { 
            Model = model; 
            Colour = colour; 
            Speed = speed;
            HasFinished = false;
        }

        public void Drive()
        {
            while (Distance <= 5000 && !HasFinished)
            {
                Thread.Sleep(1000);
                Distance += Speed;
                if (Distance >= 5000)
                {
                    HasFinished = true;
                    Console.WriteLine($"\n{Colour} {Model} has finished the race!",Console.ForegroundColor = ConsoleColor.Green);
                }
            }
        }
        public void CheckForEvent()
        {
            int originalSpeed = Speed;
            Random random = new Random();
            int randomNumber = random.Next(1, 51);

            if (randomNumber == 1) 
            {
                Console.WriteLine($"\nThe {Colour} {Model} is out of gas and needs to fill the tank!", Console.ForegroundColor = ConsoleColor.Red);
                Speed = 0;
                Thread.Sleep(20000);
                Speed = originalSpeed;
            }
            if (randomNumber == 2)
            {
                Console.WriteLine($"\nThe {Colour} {Model} activated NoS and got a huge speedboost!", Console.ForegroundColor = ConsoleColor.Green);
                Speed += 25;
            }
            else if (randomNumber >= 3 && randomNumber < 8) 
            {
                Console.WriteLine($"\nThe {Colour} {Model} have gotten a puncture and needs to switch a tire!", Console.ForegroundColor = ConsoleColor.Red);
                Speed = 0;
                Thread.Sleep(10000);
                Speed = originalSpeed;
            }
            else if (randomNumber >= 9 && randomNumber <= 18) 
            {
                Console.WriteLine($"\nA feral bird has hit the windshield of the {Colour} {Model}, we need to clean it!", Console.ForegroundColor = ConsoleColor.Red);
                Speed = 0;
                Thread.Sleep(8000);
                Speed = originalSpeed;
            }
            else if (randomNumber >= 19 && randomNumber <= 40) 
            {
                Console.WriteLine($"\nThe {Colour} {Model} have gotten some engine errors and have lost 25 km/h in speed!", Console.ForegroundColor = ConsoleColor.Red);
                Speed -= 25; 
            }
            else if (randomNumber >= 41 && randomNumber <= 51)
            {
                Console.WriteLine($"\nThe {Colour} {Model} is speeding on like never before!", Console.ForegroundColor = ConsoleColor.Green);
            }
        }

        
    }
}
