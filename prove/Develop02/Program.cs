using System;

class Program
{
    static void Main(string[] args)
    {
        int userSelection;
        Journal entry = new();
        Archive currentJournal = new();
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
            Console.WriteLine();
            switch (userSelection)
            {
                case 1:
                    WriteJournal(entry, currentJournal);
                    journalSaved = false;
                    break;
                case 2:
                    ReadJournal(currentJournal);
                    break;
                case 3:
                    SaveJournal(currentJournal);
                    journalSaved = true;
                    break;
                case 4:
                    Console.WriteLine("What file would you like to load? WARNING this will cause current entries to be lost! Enter \"c\" to cancel ");
                    string fileName = Console.ReadLine();
                    if (fileName == "c")
                    {
                        break;
                    }
                    else
                    {
                        currentJournal = LoadJournal(fileName);
                        Console.WriteLine($"{fileName} loaded successfully");
                        break;
                    }
                case 5:
                    if (journalSaved == false)
                    {
                        bool validAnswer;
                        do
                        {
                            Console.Write("Current journal is not saved. Would you like to save before exiting? (y/n): ");
                            string saveBeforeExiting = Console.ReadLine();
                            switch (saveBeforeExiting)
                            {
                                case "y":
                                    SaveJournal(currentJournal);
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
                default:
                    Console.WriteLine("Invalid entry. Please try again");
                    break;
            }

        } while (userSelection != 5);
    }

    static string SelectPrompt()
    {
        Random random = new();
        List<string> prompts = ["Prompt1", "Prompt2", "Prompt3"];
        int promptIndex = random.Next(prompts.Count);
        string prompt = prompts[promptIndex];
        return prompt;

    }
    static void WriteJournal(Journal entry, Archive currentJournal)
    {
        entry._prompt = SelectPrompt();

        Console.WriteLine(entry._prompt);
        entry._entry = Console.ReadLine();

        DateTime currentDateTime = DateTime.Now;
        entry._date = currentDateTime.ToShortDateString();

        currentJournal._entries.Add(entry);
    }

    static void ReadJournal(Archive currentJournal)
    {
        int entryCount = currentJournal._entries.Count;
        for (int i = 0; i < entryCount; i++)
        {
            Console.WriteLine($"\n({currentJournal._entries[i]._date})| {currentJournal._entries[i]._prompt}");
            Console.WriteLine($"{currentJournal._entries[i]._entry}\n");
        }
    }

    static void SaveJournal(Archive currentJournal)
    {
        currentJournal.SaveEntries();
    }

    static Archive LoadJournal(string fileName)
    {
        Archive loadedJournal = new Archive();
        loadedJournal = loadedJournal.LoadEntries(fileName);
        return loadedJournal;
    }
}