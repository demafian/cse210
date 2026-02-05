using Mindfulness;
/*
  CREATIVITY AND EXCEEDING REQUIREMENTS:
  1. UX ENHANCEMENT: Added transitional pauses and buffers so the activity results 
     and ending messages are visible for several seconds before the menu clears the screen.
  2. LOGIC ENHANCEMENT: Implemented a 'No-Repeat' system for prompts and questions. 
     The program tracks which items have been used and ensures the user doesn't see 
     a duplicate until all items in the list have been displayed once.
*/

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
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

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
        }
    }
}