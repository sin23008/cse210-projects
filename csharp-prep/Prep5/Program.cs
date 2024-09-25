using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();

        int userNumber = PromptUserNumber();

        int userNumberSquared = SquareNumber(userNumber);

        DisplayResult(userName, userNumberSquared);
    }
    // DisplayWelcome - Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("\nWelcome to the Program!\n");
    }
    // PromptUserName - Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }
    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        
        return userNumber;
    }
    // SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    static int SquareNumber(int userNumber)
    {
        return userNumber * userNumber;
    }
    // DisplayResult - Accepts the user's name and the squared number and displays them.
    static void DisplayResult(string userName, int userNumberSquared)
    {
        Console.WriteLine($"\n{userName}, the square of your number is {userNumberSquared}\n");
    }
}