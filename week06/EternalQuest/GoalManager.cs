namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // DESIGN NOTE: Keeping UI logic here prevents our Goal classes 
        // from getting cluttered with Console.ReadLine calls.
        Console.WriteLine("--- Eternal Quest Goal Tracker ---");
        Console.WriteLine("Status: System Initialized.");
        DisplayPlayerInfo();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    // STUBS FOR TEAM DISCUSSION:
    public void ListGoalDetails() { /* Logic: Loop through _goals and call GetDetailsString() */ }
    public void CreateGoal() { /* Logic: Switch statement to instantiate Simple, Eternal, or Checklist */ }
    public void RecordEvent() { /* Logic: Update score based on the returned value from Goal.RecordEvent() */ }
    public void SaveGoals() { /* DESIGN NOTE: Will use a CSV-style format for easy parsing */ }
    public void LoadGoals() { /* DESIGN NOTE: Will need to reconstruct objects from strings */ }
}