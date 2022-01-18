using System;

namespace CamelGame
{
    internal class AmbroseCamelGame
    {
        static void Main(string[] args)
        {
            // Introductory message
            Console.WriteLine("Welcome to Camel!\nYou have stolen a camel and are being pursued across the desert.\nEscape before your pursuers can catch you!");

            // Main game Loop
            bool done = false;

            // Create random 
            Random rnd = new Random();

            // Initialize variables
            int milesTraveled = 0;
            int thirst = 0;
            int camelFatigue = 0;
            int pursuerDistance = -20;
            int canteenUses = 3;

            // Start while loop
            while (!done)
            {
            //Print out option
                Console.WriteLine();
                Console.WriteLine("A. Drink from your canteen.");
                Console.WriteLine("B. Ahead moderate speed.");
                Console.WriteLine("C. Ahead full speed.");
                Console.WriteLine("D. Stop and rest.");
                Console.WriteLine("E. Status Check.");
                Console.WriteLine("Q. Quit.");
                Console.WriteLine();

                // Get user command
                Console.Write("What is your command?: ");
                string userCommand = Console.ReadLine().ToLower();
                Console.WriteLine();

                // Check if pursuers have caught up. If not, run program.
                if (pursuerDistance < 0)
                {

                    // Checks if the user wants to drink from their canteen
                    if (userCommand.Equals("a"))
                    {
                        //Checks whether canteen is full
                        if (canteenUses > 0)
                        {
                            canteenUses--;
                            thirst = 0;
                            Console.WriteLine("You drank from the canteen.");
                        }
                        else
                        {
                            Console.WriteLine("Your canteen is empty!");
                        }

                    }

                    // Check if user wants to go moderate speed ahead
                    else if (!done && userCommand.Equals("b") )
                    {
                        camelFatigue++;
                        thirst++;
                        int moderateDistance = rnd.Next(5, 13);
                        milesTraveled += moderateDistance;
                        pursuerDistance -= moderateDistance;
                        pursuerDistance += rnd.Next(7, 15);

                        // Create oasis chance and check whether it is found.
                        int oasisFound = rnd.Next(1, 20);
                        if (!done && oasisFound == 7)
                        {
                            thirst = 0;
                            camelFatigue = 0;
                            canteenUses = 3;
                            Console.WriteLine("You have found an Oasis!\nYou refill your canteen as your camel rests.");
                        }

                        // Print distance traveled
                        Console.WriteLine();
                        Console.WriteLine("You move forward " + moderateDistance + " miles.");
                        
                    }

                    // Check if the user wishes to go full speed ahead
                    else if (userCommand.Equals("c") && !done)
                    {
                        thirst++;
                        int addFatigue = rnd.Next(1, 4);
                        int fullDistance = rnd.Next(10, 21);
                        camelFatigue += addFatigue;
                        milesTraveled += fullDistance;
                        pursuerDistance -= fullDistance;
                        pursuerDistance += rnd.Next(7, 15);

                        // Create oasis chance and check whether it is found.
                        int oasisFound = rnd.Next(1, 20);
                        if (!done && oasisFound == 7)
                        {
                            thirst = 0;
                            camelFatigue = 0;
                            canteenUses = 3;
                            Console.WriteLine();
                            Console.WriteLine("You have found an Oasis!\nYou refill your canteen as your camel rests.");
                        }

                        // Print distance traveled
                        Console.WriteLine();
                        Console.WriteLine("You move forward " + fullDistance + " miles.");

                    }

                    // Check if the user has chosen to rest
                    else if (userCommand.Equals("d"))
                    {
                        camelFatigue = 0;
                        pursuerDistance += rnd.Next(7, 15);
                        Console.WriteLine();
                        Console.WriteLine("The camel is happy! ");
                    }

                    // Check if the user wishes to do a status check
                    else if (userCommand.Equals("e"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Miles traveled: " + milesTraveled);
                        Console.WriteLine("Drinks in canteen: " + canteenUses);
                        Console.WriteLine("The pursuers are " + pursuerDistance + " miles behind you.");
                    }

                    // Check if the user has chosen to quit
                    else if (userCommand.Equals("q"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You quitter. ");
                        done = true;
                    }

                    // Refuses any input other than what is outlined above
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }

                    // Check conditions related to winning or losing

                    // Check if the user has met the win conditions
                    if (milesTraveled >= 200)
                    {
                        done = true;
                        Console.WriteLine("You have made it safely across the desert!");
                        Console.WriteLine();
                        Console.WriteLine("You win!");

                    }

                    // Warn the user if they are getting thirsty
                    else if (thirst >= 4 && thirst <= 6)
                    {
                        Console.WriteLine("You are thirsty!");
                    }

                    // End the game if the user gets too thirsty
                    else if (thirst > 6)
                    {
                        done = true;
                        Console.WriteLine("You died of dehydration!\nGame Over.");
                    }
                    
                    // Warn user that the camel is tired.
                    if (camelFatigue >= 5 & !done & camelFatigue < 8)
                    {
                        Console.WriteLine("Your camel is tired.");
                    }

                    // End the game if the camel dies
                    else if (camelFatigue > 8 & !done)
                    {
                        done = true;
                        Console.WriteLine("Your camel has died and you have been caught!\nGame Over.");
                    }

                    // Warn the user that the pursuers are close by.
                    if (pursuerDistance >= -15 && !done)
                    {
                        Console.WriteLine("The pursuers are close!");
                    }
                }
                // End the game if the pursuers have caught up.
                else 
                {
                    done = true;
                    Console.WriteLine("The pursuers have caught up to you!\nYou have been killed!");
                } 
            }
        }
    }
}
