using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;

    // List to hold Job objects
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Display each job in the resume
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}