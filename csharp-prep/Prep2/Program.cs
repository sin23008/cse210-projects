using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int gradePercent = int.Parse(userInput);

        string grade = "";

        if (gradePercent >= 90)
        {
            grade = "A";
        }
        else if (gradePercent >= 80)
        {
            grade = "B";
        }
        else if (gradePercent >= 70)
        {
            grade = "C";
        }
        else if (gradePercent >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is: {grade}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}