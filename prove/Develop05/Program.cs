using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalTracker goalTracker = new();
        goalTracker.Startup();
        string userSelection;
        do
        {
            Console.WriteLine($"\nYou have {goalTracker.GetPoints()} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Progress");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            userSelection = Console.ReadLine();
            Console.WriteLine();

            switch (userSelection)
            {
                case "1":
                    goalTracker.CreateGoal();
                    break;
                case "2":
                    goalTracker.DisplayGoals();
                    break;
                case "3":
                    goalTracker.PromptSave();
                    break;
                case "4":
                    goalTracker.LoadGoals();
                    break;
                case "5":
                    goalTracker.RecordProgress();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!\n");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

        } while (userSelection != "6");
    }
}