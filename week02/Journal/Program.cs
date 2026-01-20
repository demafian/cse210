using System;

/*
  EXCEEDING REQUIREMENTS:
  1. Mood Tracking: Added a field to record the user's daily mood (1-10).
  2. Input Validation: Used int.TryParse to prevent crashes if a user types text in the menu.
  3. Error Handling: Added File.Exists checks to prevent crashes when loading missing files.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = -1;

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("Mood (1-10): ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._mood = mood;

                    theJournal.AddEntry(newEntry);
                }
                else if (choice == 2) { theJournal.DisplayAll(); }
                else if (choice == 3)
                {
                    Console.Write("Filename? ");
                    theJournal.LoadFromFile(Console.ReadLine());
                }
                else if (choice == 4)
                {
                    Console.Write("Filename? ");
                    theJournal.SaveToFile(Console.ReadLine());
                }
            }
            else { Console.WriteLine("Please enter a valid number."); }
        }
    }
}