using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();
        myResume._name = "Ryan Sinclair";

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2021;
        myResume._jobs.Add(job1);

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2021;
        job2._endYear = 2024;
        myResume._jobs.Add(job2);

        Console.WriteLine("\n");
        myResume.Display();
        Console.WriteLine("\n");
    }
}