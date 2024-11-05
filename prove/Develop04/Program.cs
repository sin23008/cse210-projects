using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string selection;
        do
        {
            Console.WriteLine("\x1B[1mMenu Options:\x1B[0m");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Breathing breathing = new();
                    breathing.Start();
                    break;
                case "2":
                    Reflection reflection = new();
                    reflection.Start();
                    break;
                case "3":
                    Listing listing = new();
                    listing.Start();
                    break;
                case "4":
                    Console.WriteLine("Quitting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select 1-4.");
                    break;
            }
        } while (selection != "4");
    }
}