using System.IO;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private List<string> _history = new List<string> { "[SYSTEM] Session initialized." };

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.Clear();
            int level = (_score / 1000) + 1;

            Console.WriteLine("==================================================================");
            Console.WriteLine($"  EXPLORER RANK: Level {level} | TOTAL PROGRESS: {_score} pts");
            Console.WriteLine("==================================================================");

            Console.WriteLine("ACTION LOG (Last 10):");
            int start = Math.Max(0, _history.Count - 10);
            for (int i = start; i < _history.Count; i++)
            {
                Console.WriteLine($" > {_history[i]}");
            }
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Progress");
            Console.WriteLine("  4. Load Progress");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": AddToHistory("[QUIT] User requested exit."); break;
            }
        }

        // PRESERVE TERMINAL TRAIL AFTER EXIT
        Console.WriteLine("\n--- FINAL SESSION LOG ---");
        int finalStart = Math.Max(0, _history.Count - 10);
        for (int i = finalStart; i < _history.Count; i++)
        {
            Console.WriteLine($" > {_history[i]}");
        }
        Console.WriteLine("==================================================================");
        Console.WriteLine("Program closed. Great work today!");
    }

    private void AddToHistory(string message)
    {
        _history.Add($"{DateTime.Now.ToString("HH:mm:ss")} {message}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\n--- DETAILED GOAL LIST ---");
        if (_goals.Count == 0) Console.WriteLine("No goals in memory.");
        else
        {
            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("\n[Press Enter to return to menu]");
        Console.ReadLine();
        AddToHistory("[VIEW] Checked goal list.");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n--- NEW GOAL ---");
        Console.WriteLine("1.Simple, 2.Eternal, 3.Checklist");
        Console.Write("Type: "); string type = Console.ReadLine();
        Console.Write("Name: "); string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) { AddToHistory("[!] Blank name rejected."); return; }
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Base Points: "); int.TryParse(Console.ReadLine(), out int pts);

        if (type == "1") _goals.Add(new SimpleGoal(name, desc, pts));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, pts));
        else if (type == "3")
        {
            Console.Write("Target completions: "); int.TryParse(Console.ReadLine(), out int target);
            Console.Write("Bonus amount: "); int.TryParse(Console.ReadLine(), out int bonus);
            _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }
        AddToHistory($"[NEW] Created '{name}'.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0) { AddToHistory("[!] Nothing to record."); return; }
        Console.WriteLine("\n--- RECORD PROGRESS ---");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation().Split(':')[1].Split(',')[0]}");

        Console.Write("\nSelection: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= _goals.Count)
        {
            if (_goals[num - 1].IsComplete() && _goals[num - 1] is SimpleGoal)
                AddToHistory($"[SKIP] '{num}' already done.");
            else
            {
                int earned = _goals[num - 1].RecordEvent();
                _score += earned;
                AddToHistory($"[RECO] Recorded '{num}'. Awarded {earned} pts.");
            }
        }
        else AddToHistory("[!] Invalid selection.");
    }

    public void SaveGoals()
    {
        Console.Write("\nFilename: ");
        string file = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(file)) { AddToHistory("[!] No filename."); return; }
        try
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(_score);
                foreach (Goal g in _goals) sw.WriteLine(g.GetStringRepresentation());
            }
            AddToHistory($"[SAVE] Saved to '{file}'.");
        }
        catch (Exception ex) { AddToHistory($"[CRIT] Save fail: {ex.Message}"); }
    }

    public void LoadGoals()
    {
        Console.Write("\nFilename: ");
        string file = Console.ReadLine();
        if (!File.Exists(file)) { AddToHistory($"[!] File '{file}' missing."); return; }
        try
        {
            string[] lines = File.ReadAllLines(file);
            _score = int.Parse(lines[0]);
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] p = lines[i].Split(':');
                string[] d = p[1].Split(',');
                if (p[0] == "SimpleGoal") _goals.Add(new SimpleGoal(d[0], d[1], int.Parse(d[2]), bool.Parse(d[3])));
                else if (p[0] == "EternalGoal") _goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2])));
                else if (p[0] == "ChecklistGoal") _goals.Add(new ChecklistGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[3]), int.Parse(d[4]), int.Parse(d[5])));
            }
            AddToHistory($"[LOAD] Loaded '{file}'.");
        }
        catch { AddToHistory("[CRIT] File corrupted."); }
    }
}