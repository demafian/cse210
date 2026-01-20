using System;

// EXCEEDING REQUIREMENTS:
// 1. Hybrid Journaling: Record spontaneous thoughts or get a prompt.
// 2. Descriptive Tagging: Replaced numerical mood with flexible vibe hashtags.
// 3. Smart Session Logic: Save files only contain new thoughts from current session.
// 4. Input Validation: Robust handling of missing files and non-numeric menu choices.

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
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    Console.WriteLine("\nRecord a thought? (Leave blank for a random prompt)");
                    Console.Write("> ");
                    string userInput = Console.ReadLine();

                    string finalPrompt = string.IsNullOrWhiteSpace(userInput) ? promptGenerator.GetRandomPrompt() : "Spontaneous Note";

                    if (finalPrompt != "Spontaneous Note")
                    {
                        Console.WriteLine($"\nPrompt: {finalPrompt}");
                        Console.Write("> ");
                        userInput = Console.ReadLine();
                    }

                    Console.Write("Tag the 'vibe' of this entry (e.g. Hopeful, Tired): ");
                    string tag = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = finalPrompt;
                    newEntry._entryText = userInput;
                    newEntry._tag = tag;

                    theJournal.AddEntry(newEntry);
                }
                else if (choice == 2) theJournal.DisplayAll();
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
            else Console.WriteLine("Please enter a valid number (1-5).");
        }
    }
}