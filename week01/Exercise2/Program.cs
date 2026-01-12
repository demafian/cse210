using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Core Requirement 1: Input & Conversion ---
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        // --- Core Requirement 3: Determine Letter Grade ---
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // --- Stretch Challenge: Determine Sign (+/-) ---
        string sign = "";
        int lastDigit = percent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // --- Stretch Challenge: Handle Exceptions (A+, 100%, F) ---
        // 1. Handle "A" exceptions: No A+, and 100 should not be A-
        if (letter == "A")
        {
            if (sign == "+" || percent >= 100)
            {
                sign = "";
            }
        }

        // 2. Handle "F" exceptions: No F+ or F-
        if (letter == "F")
        {
            sign = "";
        }

        // --- Output the Final Grade ---
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // --- Core Requirement 2: Pass/Fail Message ---
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! You'll get it next time.");
        }
    }
}