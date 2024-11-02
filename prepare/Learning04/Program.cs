using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nBase:");
        Assignment First = new("Samuel Bennett", "Multiplication");
        Console.WriteLine(First.GetSummary());

        Console.WriteLine("\nMath:");
        MathAssignment Second = new("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(Second.GetSummary());
        Console.WriteLine(Second.GetHomeworkList());

        Console.WriteLine("\nWriting:");
        WritingAssignment Third = new("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(Third.GetSummary());
        Console.WriteLine(Third.GetWritingInformation());
    }
}