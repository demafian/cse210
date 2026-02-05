namespace Mindfulness;

/*
  PRESENTATION NOTES:
  - This is a DERIVED CLASS (The Child).
  - It demonstrates the 'is-a' relationship: A BreathingActivity IS AN Activity.
  - Notice the ': base()' call in the constructor; it passes data up to the Parent.
*/

public class BreathingActivity : Activity
{
    // ROADMAP STEP 1: Constructor with Base Initialization
    // We provide the specific Name and Description here, but the Parent (Activity) 
    // actually stores and manages them.
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    // ROADMAP STEP 2: The Core Loop
    // This is the specific logic that makes Breathing unique from Listing or Reflecting.
    public void Run()
    {
        // 1. Call the Parent's startup logic
        DisplayStartingMessage();

        // 2. Calculate session timing based on user input stored in the Parent (_duration)
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // 3. Rhythmic Loop
        // We alternate between "In" and "Out" until the time expires.
        while (DateTime.Now < endTime)
        {
            // PRESENTATION POINT: We reuse 'ShowCountDown' from the Parent class.
            // This ensures all activities have a consistent visual "feel."

            Console.Write("\nBreathe in...");
            ShowCountDown(4);

            Console.Write("\nNow breathe out...");
            ShowCountDown(6); // Longer exhale for increased relaxation (UX detail)
            Console.WriteLine();
        }

        // 4. Call the Parent's closing logic
        DisplayEndingMessage();
    }
}