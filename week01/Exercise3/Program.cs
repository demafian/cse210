using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";

        Console.WriteLine("Welcome to the Guess My Number Game!");

        while (response == "yes")
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("I'm thinking of a number between 1 and 100...");
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int count = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                // Using TryParse is a safer way to handle non-number inputs
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out guess))
                {
                    count++;

                    if (magicNumber > guess)
                    {
                        Console.WriteLine("Higher ↑\n"); // Added arrow and newline
                    }
                    else if (magicNumber < guess)
                    {
                        Console.WriteLine("Lower ↓\n"); // Added arrow and newline
                    }
                    else
                    {
                        Console.WriteLine("\n🎉 You guessed it!");
                        Console.WriteLine($"It took you {count} guesses.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.\n");
                }
            }

            Console.Write("\nDo you want to play again (yes/no)? ");
            response = Console.ReadLine().ToLower();
        }

        Console.WriteLine("\nThanks for playing! Goodbye.");
    }
}