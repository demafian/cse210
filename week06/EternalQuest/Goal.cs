namespace EternalQuest;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // DESIGN NOTE: RecordEvent is abstract because a SimpleGoal marks completion 
    // while a ChecklistGoal increments a counter. No default behavior works for both.
    public abstract void RecordEvent();

    public abstract bool IsComplete();

    // DESIGN NOTE: We use 'virtual' so only classes that need a special 
    // display (like ChecklistGoal) have to override it.
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}