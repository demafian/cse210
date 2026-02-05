namespace Mindfulness;

/*
  PRESENTATION NOTES:
  - This class demonstrates advanced data management using List<T>.
  - CREATIVITY FEATURE: The 'No-Repeat' logic ensures the user doesn't see 
    the same question twice in a single session.
  - KEY OOP CONCEPT: Private member variables encapsulate the data specific 
    only to this activity.
*/

public class ReflectingActivity : Activity
{
    // ROADMAP STEP 1: Data Storage
    // These are the master lists that remain constant.
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?"
    };

    // ROADMAP STEP 2: Logic Tracking (Creativity Implementation)
    // These lists act as 'buckets'. We pull items out until the bucket is empty, 
    // then refill it. This prevents immediate repeats.
    private List<string> _unusedPrompts = new List<string>();
    private List<string> _unusedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength.")
    {
        // Initialize the 'working' lists with a copy of the master lists
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();

        // ROADMAP STEP 3: Handle the Prompt selection
        // Logic: Check if we have prompts left. If not, reset the 'bucket'.
        if (_unusedPrompts.Count == 0) _unusedPrompts = new List<string>(_prompts);

        int promptIndex = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[promptIndex];
        _unusedPrompts.RemoveAt(promptIndex); // Pull the item out of the 'unused' list

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        // ROADMAP STEP 4: Transition to Questions
        Console.WriteLine("Now ponder on each of the following questions.");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Reuse Parent method
        Console.Clear();

        // ROADMAP STEP 5: The Reflection Loop
        // Continues until the duration (inherited from Parent) is reached.
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            // Reset question bucket if empty
            if (_unusedQuestions.Count == 0) _unusedQuestions = new List<string>(_questions);

            int questionIndex = random.Next(_unusedQuestions.Count);
            string question = _unusedQuestions[questionIndex];
            _unusedQuestions.RemoveAt(questionIndex);

            // DISPLAY LOGIC: Show question and pause for reflection
            Console.Write($"> {question} ");
            ShowSpinner(10); // Using the Parent spinner to give the user time to think
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}