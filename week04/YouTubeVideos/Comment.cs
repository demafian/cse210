namespace YouTubeVideos; // The container that keeps our Comment blueprint organized with the rest of the project.

public class Comment // The blueprint for an individual feedback entry on a video.
{
    // Properties: The "name tag" and the "message" that the outside world can read or write.
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor: The "birth" of the comment. 🐣 
    // It takes the raw strings (name and text) and assigns them to the properties above.
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}