using System;
using System.Collections.Generic;
using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {
        // Create one of each activity
        Running run = new Running("03 Nov 2022", 30, 4.8);
        Cycling bike = new Cycling("03 Nov 2022", 30, 9.7);
        Swimming swim = new Swimming("03 Nov 2022", 30, 20);

        // Put them in the same list (Polymorphism)
        List<Activity> activities = new List<Activity>();
        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        // Iterate and display summaries
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("------------------------------------------------------------------");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("------------------------------------------------------------------");
    }
}