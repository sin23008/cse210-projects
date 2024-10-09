using System.Runtime.CompilerServices;

public class Journal
{
    // Attributes
    public List<Entry> _entries = new List<Entry>();
    public string _file;

    // Methods
    public void SaveEntries()
    {
        // Check if _file is provided
        if (string.IsNullOrEmpty(_file))
        {
            Console.Write("Please provide a file name: ");
            _file = Console.ReadLine();
        }
        // Check if file provided already exists
        if (File.Exists(_file))
        {
            // If the file already exists, give saving options
            bool validOption;
            do
            {
                Console.Write("A file with this name already exists. Do you wish to 1. Overwrite file, 2. Append to file, or 3. Cancel? ");
                string saveOption = Console.ReadLine();
                if (int.TryParse(saveOption, out int saveOptionInt)) // Checks to make sure input is an int
                {
                    switch (saveOptionInt)
                    {
                        case 1: // Clear file, then write using append mode
                            // Clear the file
                            using (StreamWriter outputFile = new StreamWriter(_file))
                            {
                                File.WriteAllText(_file, string.Empty);
                            }
                            //Write in append
                            foreach (Entry entry in _entries)
                            {
                                using (StreamWriter outputFile = new StreamWriter(_file, append: true))
                                {
                                    outputFile.Write($"{entry._date}|{entry._prompt}|{entry._entry}~");
                                }
                            }
                        break;
                        case 2: // Append to file
                            foreach (Entry entry in _entries)
                            {
                                using (StreamWriter outputFile = new StreamWriter(_file, append: true))
                                {
                                    outputFile.Write($"{entry._date}|{entry._prompt}|{entry._entry}~"); // Uses | as delimiter for segments of entry, and uses ~ as delimiter to seperate entries
                                }
                            }
                        break;
                        case 3: // Cancel save
                            Console.WriteLine("Save cancelled");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Save aborted");
                            break;
                    }
                    validOption = true;
                }
                // If user input was invalid
                else // If input was not a valid int
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    validOption = false;
                }
            } while (validOption == false);
        }
        // If the file provided does not already exist
        else
        {
            foreach (Entry entry in _entries)
            {
                using (StreamWriter outputFile = new StreamWriter(_file, append: true))
                {
                    outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._entry}~");
                }
            }
        }
    }

    public Journal LoadJournal(string fileName)
    {
        Journal loadedJournal = new Journal();
        loadedJournal._file = fileName;

        string[] lines = File.ReadAllLines(fileName); // Read file into array
        foreach (string line in lines)
        {
            string[] rawEntry = line.Split("~"); // Splits entries using ~ delimiter
            foreach (string entryString in rawEntry)
            {
                Entry entry = new Entry();
                string[] parsedString = entryString.Split("|"); // Splits entry segments using | delimiter
                if(parsedString[0] != "") // Avoids errors of blank entries
                {
                    entry._date = parsedString[0];
                    entry._prompt = parsedString[1];
                    entry._entry = parsedString[2];
                    loadedJournal._entries.Add(entry);
                }
            }
        }
        return loadedJournal;
    }
    public void ReadJournal()
    {
        int entryCount = this._entries.Count;
        for (int i = 0; i < entryCount; i++)
        {
            Console.WriteLine($"\n({this._entries[i]._date})| {this._entries[i]._prompt}");
            Console.WriteLine($"{this._entries[i]._entry}\n");
        }
    }

    // Redundant method
    // public Journal LoadJournal(string fileName)
    // {
    //     Journal loadedJournal = new Journal();
    //     loadedJournal = loadedJournal.LoadEntries(fileName);
    //     return loadedJournal;
    // }
}