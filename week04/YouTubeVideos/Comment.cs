namespace YouTubeVideos;

public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // PROVIDER METHOD: Returns the formatted string for the display loop.
    public string GetFormattedComment() => $"{_name}: \"{_text}\"";
}