using Mindfulness;

/*
  CREATIVITY AND EXCEEDING REQUIREMENTS:
  1. UX ENHANCEMENT: Added transitional pauses and buffers so the activity results 
     and ending messages are visible for several seconds before the menu clears the screen.
  2. LOGIC ENHANCEMENT: Implemented a 'No-Repeat' system for prompts and questions. 
     The program tracks which items have been used and ensures the user doesn't see 
     a duplicate until all items in the list have been displayed once.
*/

/*
  PRESENTATION NOTES:
  - This is the Entry Point of the application.
  - It manages the user's session and selection flow.
*/

class Program
{
    static void Main(string[] args)
    {
        // ROADMAP STEP 1: Initialize control variables
        string choice = "";

        // ROADMAP STEP 2: Main Application Loop
        // Keeps the program running so the user can try multiple activities.
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            // ROADMAP STEP 3: Activity Execution
            // Each choice creates an instance of a Derived Class that inherits from 'Activity'.

            if (choice == "1")
            {
                // PRESENTATION POINT: Breathing focuses on simple rhythmic timing.
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                // PRESENTATION POINT: Reflecting uses the 'No-Repeat' logic for questions.
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                // PRESENTATION POINT: Listing captures user input and provides a final count.
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }

            // ROADMAP STEP 4: Loop Return
            // After the activity's Run() method finishes, we return here to show the menu again.
        }

        Console.WriteLine("Thank you for practicing mindfulness today. Goodbye!");
    }
}