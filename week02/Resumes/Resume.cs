using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;

    // Initialize the list to avoid "null reference" errors
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate through each job in the list
        foreach (Job job in _jobs)
        {
            // Call the Display method from the Job class
            job.Display();
        }
    }
}