using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private List<Entry> _newSessionEntries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        // Duplicate check to keep the display clean
        bool isDuplicate = _entries.Any(e =>
            e._date == newEntry._date &&
            e._promptText == newEntry._promptText &&
            e._entryText == newEntry._entryText);

        if (!isDuplicate)
        {
            _entries.Add(newEntry);
            _newSessionEntries.Add(newEntry);
        }
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        if (_newSessionEntries.Count == 0)
        {
            Console.WriteLine("No new entries to save from this session.");
            return;
        }

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _newSessionEntries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._tag}");
            }
        }
        _newSessionEntries.Clear(); // Reset session tracker after successful save
        Console.WriteLine($"Current session saved to {file}. Historical data excluded.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            int addedCount = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 4)
                {
                    Entry entryFromFile = new Entry();
                    entryFromFile._date = parts[0];
                    entryFromFile._promptText = parts[1];
                    entryFromFile._entryText = parts[2];
                    entryFromFile._tag = parts[3];

                    // Check duplicate so loading doesn't clutter the display
                    bool isDuplicate = _entries.Any(e =>
                        e._date == entryFromFile._date &&
                        e._entryText == entryFromFile._entryText);

                    if (!isDuplicate)
                    {
                        _entries.Add(entryFromFile);
                        addedCount++;
                    }
                }
            }
            Console.WriteLine($"Loaded {addedCount} unique entries from {file}.");
        }
        else
        {
            Console.WriteLine($"Error: File '{file}' not found.");
        }
    }
}