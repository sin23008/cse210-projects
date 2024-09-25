using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userInput = -1;

        Console.WriteLine("Enter a list of numbers. Enter 0 when finished");
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput !=0)
            {
                numbers.Add(userInput);
            }
        };

        int listSum = numbers.Sum();
        Console.WriteLine($"The sum is: {listSum}");

        double listAvg = numbers.Average();
        Console.WriteLine($"The average is: {listAvg}");

        int listMax = numbers.Max();
        Console.WriteLine($"The largest number is: {listMax}");

        numbers = numbers.Order().ToList();

        int? positiveMin = null;
        foreach (int number in numbers)
        {
            if (number > 0)
            {
                positiveMin = number;
                break;
            }
        }
        Console.WriteLine($"The smallest positive number is {positiveMin}");


        Console.WriteLine("These are your entries in ascending order:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        
    }
}