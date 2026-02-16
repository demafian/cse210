using System;
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        // PRESENTATION NOTE: Keep Program.cs minimal. 
        // All menu logic is delegated to the GoalManager to achieve "Separation of Concerns."
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}