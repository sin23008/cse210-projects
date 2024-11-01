using System;

class Program
{
    static void Main(string[] args)
    {
        string selection;
        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from a menu: ");
            selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    // Start breathing activity
                case "2":
                    // Start reflecting activity
                case "3":
                    // Start listing activity
                case "4":
                    Console.WriteLine("Quitting...");
                    break;
                default:
                    break;
            }
        } while (selection != "4");
    }
}