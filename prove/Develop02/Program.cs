using System;

class Program
{
    static void Main(string[] args)
    {
        // Initializing variables
        int userSelection;
        Entry entry = new();
        Journal currentJournal = new();
        bool journalSaved = true;

        do
        {
            Console.WriteLine("\nPlease select one of the following choices:\n1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.Write("What would you like to do? ");
            //check for valid input
            if (!int.TryParse(Console.ReadLine(), out userSelection))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;  // Skip the rest of the do-while loop if input is invalid
            }
            Console.WriteLine(); // Blank line

            switch (userSelection)
            {
                case 1: // Write Journal
                    entry.NewEntry(currentJournal);
                    journalSaved = false; // Causes save warning to appear if not saved after this point
                    break;
                case 2: // Read Journal
                    currentJournal.ReadJournal();
                    break;
                case 3: // Save Journal
                    currentJournal.SaveEntries();
                    journalSaved = true; // Satisfies requirement to avoid save warning
                    break;
                case 4: // Load Journal
                    Console.WriteLine("What file would you like to load? WARNING this will cause current entries to be lost! Enter \"c\" to cancel ");
                    string fileName = Console.ReadLine();
                    if (fileName == "c") // This is to prevent losing unsaved entries by loading new journal
                    {
                        break;
                    }
                    else // If not cancelled
                    {
                        currentJournal = currentJournal.LoadJournal(fileName);
                        Console.WriteLine($"{fileName} loaded successfully");
                        break;
                    }
                case 5: // Exit
                    if (journalSaved == false) // Save warning to prevent loss of data
                    {
                        bool validAnswer;
                        do
                        {
                            Console.Write("Current journal is not saved. Would you like to save before exiting? (y/n): ");
                            string saveBeforeExiting = Console.ReadLine();
                            switch (saveBeforeExiting)
                            {
                                case "y":
                                    currentJournal.SaveEntries();
                                    validAnswer = true;
                                    break;
                                case "n":
                                    validAnswer = true;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please try again\n");
                                    validAnswer = false;
                                    break;
                            }
                        } while (validAnswer == false);
                    }
                    break;
                default: // For invalid entries
                    Console.WriteLine("Invalid entry. Please try again");
                    break;
            }
        } while (userSelection != 5); // Ends program when option 5 is selected
    }
}