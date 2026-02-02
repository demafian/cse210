namespace YouTubeVideos; // Keeps all related code in one "container."

public class Video // An "open door" blueprint accessible by any part of the program.
{
    // Public Properties: Visible to the outside world for easy reading/display.
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Represented in seconds.

    // Private Field: An internal "database" hidden from outside interference.
    private List<Comment> _comments = new List<Comment>();

    // Constructor: The "factory setup" that ensures every video is born with a title, author, and length.
    public Video(string title, string author, int length)
    {
        // Taking the "raw materials" from parameters and assigning them to our public properties.
        Title = title;
        Author = author;
        Length = length;
    }

    // Receiver Method: Acts as the only "gateway" to safely add data to our private internal list.
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Reporter Method: Calculates the size of the list and "hands back" the total count as an integer.
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Provider Method: Hands over the entire "box" of comments so they can be displayed.
    public List<Comment> GetComments()
    {
        return _comments;
    }
}