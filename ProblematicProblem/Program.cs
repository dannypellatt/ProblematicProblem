using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProblematicProblem
{
    public class Program
    {
        public static Random rng = new Random();
        bool cont = true;
        static List<string> activities = new List<string>() {
                                                            "Movies",
                                                            "Paintball",
                                                            "Bowling",
                                                            "Lazer Tag",
                                                            "LAN Party",
                                                            "Hiking",
                                                            "Axe Throwing",
                                                            "Wine Tasting" };



        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \n" +
                "Would you like to generate a random activity? yes/no: ");
            bool cont = "yes".Equals(Console.ReadLine());
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no thanks: ");
            bool seeList = Console.ReadLine().ToLower() == "yes";
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = "yes".Equals(Console.ReadLine().ToLower());
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(50);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower() == "yes";
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! " +
                    $"Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string ans = Console.ReadLine().ToLower();
                if (ans == "keep")
                {
                    Console.WriteLine($"Great! {userName}, your random activity is: {randomActivity}!");
                    break;
                }
                else if (ans == "redo")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("That's not an option, please try again.");
                    continue;
                }
            }
        }
    }
}

