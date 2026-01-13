using System;

class Program
{
    static void Main(string[] args)
    {
        // Call each function and save return values where necessary
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // 1. DisplayWelcome - Displays the message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // 2. PromptUserName - Asks for and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // 3. PromptUserNumber - Asks for and returns favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // 4. SquareNumber - Accepts an integer and returns it squared
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // 5. DisplayResult - Accepts name and squared number, then displays them
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}