namespace Homework;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // This method is available to all derived classes automatically
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // We provide a Getter so derived classes can access the private name
    public string GetStudentName()
    {
        return _studentName;
    }
}