using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Core Requirement 1: Input First Name ---
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // --- Core Requirement 2: Input Last Name ---
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // --- Core Requirement 3: Output Formatted Name ---
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}