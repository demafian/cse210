namespace Mindfulness;

/*
  PRESENTATION NOTES:
  - This is the BASE CLASS (The Parent).
  - It uses 'protected' variables so that Children (Breathing, etc.) 
    can access them, but external classes cannot.
  - KEY FEATURE: Universal animations (Spinner/Countdown) are defined 
    once here to be used everywhere.
*/

public class Activity
{
    // ROADMAP STEP 1: Define shared attributes
    protected string _name;
    protected string _description;
    protected int _duration;

    // ROADMAP STEP 2: Constructor
    // This allows children to pass their specific names and descriptions up to the parent.
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        // ROADMAP STEP 3: Setup the Session
        // 1. Clear screen for focus.
        // 2. Display the specific activity name and description.
        // 3. Capture user duration input to be used by the 'Run' logic later.

        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        // STUB: For now, we assume valid integer input. 
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        // ROADMAP STEP 4: Standardized Conclusion
        // UX ENHANCEMENT: Notice the 5-second spinner at the end. 
        // This ensures the user actually sees their accomplishment before the menu wipes it.

        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");

        // PRESENTATION POINT: This 'Buffer' pause is part of my Creativity requirement.
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        // ROADMAP STEP 5: Visual Feedback Logic
        // Uses a loop and backspaces (\b) to create a rotating character animation.

        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animationStrings.Count) i = 0;
        }
    }

    public void ShowCountDown(int seconds)
    {
        // ROADMAP STEP 6: Precision Timing
        // Used for the breathing rhythms and reflection pauses.

        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}