namespace YouTubeVideos;

public class Video
{
    // ENCAPSULATION: Member variables are private with _underscoreCamelCase.
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment) => _comments.Add(comment);

    public int GetCommentCount() => _comments.Count;

    // ABSTRACTION: This method handles the display logic, 
    // keeping Program.cs clean and focused on high-level flow.
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  - {comment.GetFormattedComment()}");
        }
        Console.WriteLine(new string('-', 40));
    }
}