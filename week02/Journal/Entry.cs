using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _tag;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Type: {_promptText}");
        Console.WriteLine($"Vibe/Tag: #{_tag}");
        Console.WriteLine($"{_entryText}\n");
    }
}