namespace Mindfulness;

public class ReflectingActivity : Activity
{
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

    // Lists to track unused items
    private List<string> _unusedPrompts = new List<string>();
    private List<string> _unusedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength.")
    {
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();

        // Get a prompt that hasn't been used
        if (_unusedPrompts.Count == 0) _unusedPrompts = new List<string>(_prompts);
        int promptIndex = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[promptIndex];
        _unusedPrompts.RemoveAt(promptIndex);

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            // Reset question list if all are used
            if (_unusedQuestions.Count == 0) _unusedQuestions = new List<string>(_questions);

            int questionIndex = random.Next(_unusedQuestions.Count);
            string question = _unusedQuestions[questionIndex];
            _unusedQuestions.RemoveAt(questionIndex);

            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}