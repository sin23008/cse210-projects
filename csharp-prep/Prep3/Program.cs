using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNum = new Random();
        int secretNum = randomNum.Next(1, 101);
        int userInput = -1;
        while (userInput != secretNum)
        {
            Console.Write("Please enter a guess: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput < secretNum)
            {
                Console.WriteLine("Higher!\n");
            }
            else if (userInput > secretNum)
            {
                Console.WriteLine("Lower!\n");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
        }
    }
}