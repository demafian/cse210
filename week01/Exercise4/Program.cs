using System;
using System.Collections.Generic; // Necessary for Lists
using System.Linq;               // Necessary for .Sum(), .Average(), and .Max()

class Program
{
    static void Main(string[] args)
    {
        // Welcome Message
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("   Welcome to the C# List Analyzer tool!   ");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Instructions: Enter a series of numbers.");
        Console.WriteLine("Press ENTER after each number. Type 0 to finish.\n");

        List<int> numbers = new List<int>();
        int userNumber = -1;

        // --- Core Requirement: Input Loop ---
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // TryParse prevents the crash you saw earlier
            if (int.TryParse(input, out userNumber))
            {
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single whole number.");
            }
        }

        // Check if the list is empty to avoid errors
        if (numbers.Count > 0)
        {
            // --- Core Requirements: Calculations ---
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine("\n--- Results ---");
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // --- Stretch Challenge 1: Smallest Positive Number ---
            // We want the positive number closest to zero
            int smallestPositive = int.MaxValue;
            foreach (int n in numbers)
            {
                if (n > 0 && n < smallestPositive)
                {
                    smallestPositive = n;
                }
            }

            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // --- Stretch Challenge 2: Sorted List ---
            numbers.Sort();
            Console.WriteLine("\nThe sorted list is:");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }

        Console.WriteLine("\nThank you for using the List Analyzer. Goodbye!");
    }
}