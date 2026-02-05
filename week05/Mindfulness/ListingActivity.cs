namespace Mindfulness;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    { }

    public void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();

        Console.WriteLine("\nList as many items as you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[random.Next(_prompts.Count)]} --- ");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userEntries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrEmpty(entry))
            {
                userEntries.Add(entry);
            }
        }

        Console.WriteLine($"\nYou listed {userEntries.Count} items!");
        DisplayEndingMessage();
    }
}