namespace Mindfulness;

/*
  PRESENTATION NOTES:
  - This class focuses on 'User Input Collection'.
  - It demonstrates how a Derived Class can have its own unique local data 
    (the 'userEntries' list) while still relying on the Parent for the timer.
  - KEY DIFFERENCE: Unlike 'Reflecting', this activity measures quantity 
    of responses.
*/

public class ListingActivity : Activity
{
    // ROADMAP STEP 1: Activity-Specific Data
    // These prompts are unique to the Listing context.
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    // ROADMAP STEP 2: Inheritance Link
    // Passes the name and description up to the Activity Parent.
    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    { }

    public void Run()
    {
        // 1. Call Parent startup (captures duration, shows intro)
        DisplayStartingMessage();

        Random random = new Random();

        // ROADMAP STEP 3: Prompt Setup
        Console.WriteLine("\nList as many items as you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[random.Next(_prompts.Count)]} --- ");
        Console.Write("You may begin in: ");

        // Reuse Parent countdown for consistency
        ShowCountDown(5);
        Console.WriteLine();

        // ROADMAP STEP 4: Data Collection Phase
        // We create a temporary list to store user responses for the final count.
        List<string> userEntries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // This loop keeps accepting input until the clock runs out.
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();

            // Check to ensure we don't count empty 'Enter' presses
            if (!string.IsNullOrEmpty(entry))
            {
                userEntries.Add(entry);
            }
        }

        // ROADMAP STEP 5: Feedback and Wrap-up
        // Presenting the results to the user before the final sign-off.
        Console.WriteLine($"\nYou listed {userEntries.Count} items!");

        // 2. Call Parent ending (shows completion message and buffer)
        DisplayEndingMessage();
    }
}