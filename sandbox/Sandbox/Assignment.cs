namespace ConsoleApp1; // This "addresses" the file so Program.cs can find it

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"{_studentName} is working on {_topic}.");
    }
}