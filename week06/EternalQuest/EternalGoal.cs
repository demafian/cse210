namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false; // Eternal goals are never "finished"

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}