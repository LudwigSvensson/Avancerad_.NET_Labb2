using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avancerad_.NET_Labb2
{
    internal class RaceManager
    {
        private static List<Car> cars = new List<Car>();
        public void SetupRace()
        {

            CreateCars();

            StartLines();
            Countdown();

            CreateCarThreads(cars);

            CreateUserThread(cars);

            StartCarThreads(CreateCarThreads(cars));

            RaceAccidents(cars);

            CalculateStandings(cars);

            EndRace();
        }

        private static void EndRace()
        {
            Console.WriteLine("The race is over, shuting down console....");
            Environment.Exit(0);
        }

        private void CreateUserThread(List<Car> cars)
        {
            Thread userInputThread = new Thread(() => UserInputHandler(cars));
            userInputThread.Start();
        }

        private static void StartLines()
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"On the start lines today:" +
                            $"\nThe {car.Colour} {car.Model}");
            }
        }

        private static void RaceAccidents(List<Car> cars)
        {
            while (!AllCarsFinished(cars))
            {
                foreach (var car in cars)
                {
                    if (!car.HasFinished)
                        car.CheckForEvent();
                }
                Thread.Sleep(10000);
            }
        }

        private static bool AllCarsFinished(List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (!car.HasFinished)
                    return false;
            }
            return true;
        }

        private static void StartCarThreads(List<Thread> threads)
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        private static void CalculateStandings(List<Car> cars)
        {
            Console.Clear();
            cars.Sort((x, y) => y.Distance.CompareTo(x.Distance));
            Console.WriteLine("Final Standings:");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i].Colour} {cars[i].Model}");
            }
        }
        private void UserInputHandler(List<Car> cars)
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "info")
                {
                    Console.WriteLine("--------------------------", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.WriteLine("Race status:");
                    foreach (var car in cars)
                    {
                        PrintRaceStatus(car);
                    }
                    Console.WriteLine("--------------------------", Console.ForegroundColor = ConsoleColor.Yellow);
                }
            }
        }
        private static void PrintRaceStatus(Car car)
        {
            Console.WriteLine($"{car.Colour} {car.Model} has driven {car.Distance} km.", Console.ForegroundColor = ConsoleColor.Yellow);
            if (car.HasFinished)
            {
                Console.WriteLine($"{car.Colour} {car.Model} has finished the race!", Console.ForegroundColor = ConsoleColor.Yellow);
            }
        }
        private static List<Thread> CreateCarThreads(List<Car> cars)
        {
            List<Thread> carThreads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread thread = new Thread(car.Drive);
                carThreads.Add(thread);
            }
            return carThreads;
        }

        private static void CreateCars()
        {
            cars.Add(new Car("Mercedes", "Red", 120));
            cars.Add(new Car("Porsche", "Blue", 120));
            cars.Add(new Car("Volvo", "Black", 120));
            cars.Add(new Car("Fiat Panda", "Purple", 120));
            
        }

        static void Countdown()
        {
            for (int i = 5; i >= 0; i--)
            {
                Console.Clear();
                Console.WriteLine("  _     _     _     _    ");
                Console.WriteLine(" / \\   / \\   / \\   / \\ ");
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {i} ");
                Console.ResetColor();
                Console.Write(")");
                Console.Write(" (");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {i} ");
                Console.ResetColor();
                Console.Write(")");
                Console.Write(" (");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {i} ");
                Console.ResetColor();
                Console.Write(")");
                Console.Write(" (");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {i} ");
                Console.ResetColor();
                Console.WriteLine(")");
                Console.WriteLine(" \\_/   \\_/   \\_/   \\_/ ");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("\r\n   _____ _           ______                ______            _           _ _ \r\n  |_   _| |          | ___ \\               | ___ \\          (_)         | | |\r\n    | | | |__   ___  | |_/ /__ _  ___ ___  | |_/ / ___  __ _ _ _ __  ___| | |\r\n    | | | '_ \\ / _ \\ |    // _` |/ __/ _ \\ | ___ \\/ _ \\/ _` | | '_ \\/ __| | |\r\n    | | | | | |  __/ | |\\ \\ (_| | (_|  __/ | |_/ /  __/ (_| | | | | \\__ \\_|_|\r\n    \\_/ |_| |_|\\___| \\_| \\_\\__,_|\\___\\___| \\____/ \\___|\\__, |_|_| |_|___(_|_)\r\n                                                        __/ |                \r\n                                                       |___/                 \r\n");
        }
    }
}
