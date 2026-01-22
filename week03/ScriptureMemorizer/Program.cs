using System;

// Program: Scripture Memorizer
// Author: Sizwe Athur Nkosi
//
// Exceeding Requirements:
// 1. Added a "Scripture Library" system that randomly selects a scripture from a list 
//    so the user gets a different challenge each time they run the program.
// 2. Enhanced the HideRandomWords logic to be "smart"—it strictly selects from a list 
//    of words that are NOT already hidden, ensuring the program progresses efficiently
//    and never attempts to hide the same word twice.

class Program
{
    static void Main(string[] args)
    {
        // Create a small library of scriptures
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.")
        };

        // Randomly select one scripture from the library
        Random random = new Random();
        Scripture selectedScripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit:");

            string input = Console.ReadLine();

            // End if user quits or if all words are hidden
            if (input.ToLower() == "quit" || selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            // Hide 3 words at a time
            selectedScripture.HideRandomWords(3);
        }

        // Final display showing the fully hidden scripture before closing
        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Good luck memorizing!");
    }
}