using System;

namespace CamelGame
{
    internal class AmbroseCamelGame
    {
        static void Main(string[] args)
        {
            // Introductory message
            Console.WriteLine("Welcome to Camel!");

            // Main game Loop
            bool done = false;

            // Initialize variables
            int milesTraveled = 0;
            int thirst = 0;
            int camelFatigue = 0;
            int pursuerDistance = -20;
            int canteenUses = 3;

            // Create random 
            Random rnd = new Random();

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("A. Drink from your canteen.");
                Console.WriteLine("B. Ahead moderate speed.");
                Console.WriteLine("C. Ahead full speed.");
                Console.WriteLine("D. Stop and rest.");
                Console.WriteLine("E. Status Check.");
                Console.WriteLine("Q. Quit.");
                Console.WriteLine();

                // Get user command
                Console.Write("What is your command? ");
                string userCommand = Console.ReadLine();

                // Process user command
                if (userCommand.Equals("a", StringComparison.OrdinalIgnoreCase))
                {
                    canteenUses -= 1;
                    Console.WriteLine("");
                    Console.WriteLine("You drank from the canteen.");
                }
                else if (userCommand.Equals("b", StringComparison.OrdinalIgnoreCase))
                {
                    camelFatigue += 1;
                    thirst += 1;

                    Console.WriteLine("");
                    Console.WriteLine("You move forward " + rnd(5, 13) "miles. ");
                }
                else if (userCommand.Equals("c", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("You move forward " + " miles.");
                }
                else if (userCommand.Equals("d", StringComparison.OrdinalIgnoreCase))
                {
                    camelFatigue = 0;
                    pursuerDistance += rnd.Next(7, 15);
                    Console.WriteLine("");
                    Console.WriteLine("The camel is happy! ");
                }
                else if (userCommand.Equals("e", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Miles traveled: " + milesTraveled);
                    Console.WriteLine("Drinks in canteen: " + canteenUses);
                    Console.WriteLine("The pursuers are " + pursuerDistance + " miles behind you.");
                }
                else if (userCommand.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("You quitter. ");
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}
