using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. General worker role from your 2025 experience
        Job job1 = new Job();
        job1._jobTitle = "General Worker - Construction & Operations"; // [cite: 41]
        job1._company = "MRW Projects";
        job1._startYear = 2025;
        job1._endYear = 2025;

        // 2. Quality Manager role from your 2023 experience
        Job job2 = new Job();
        job2._jobTitle = "Quality Manager - Warehouse & Operations"; // [cite: 47]
        job2._company = "Professional Risk and Asset Management"; // [cite: 48]
        job2._startYear = 2023;
        job2._endYear = 2023;

        // 3. Create personalized Resume object
        Resume myResume = new Resume();
        myResume._name = "Sizwe Athur Nkosi";

        // 4. Add jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // 5. Display the resume
        myResume.Display();
    }
}