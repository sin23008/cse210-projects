public class Archive
{
    // Attributes
    public List<Journal> _entries = new List<Journal>();
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
                if (int.TryParse(saveOption, out int saveOptionInt))
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
                            foreach (Journal entry in _entries)
                            {
                                using (StreamWriter outputFile = new StreamWriter(_file, append: true))
                                {
                                    outputFile.Write($"{entry._date}|{entry._prompt}|{entry._entry}~");
                                }
                            }
                        break;
                        case 2: // Append to file
                            foreach (Journal entry in _entries)
                            {
                                using (StreamWriter outputFile = new StreamWriter(_file, append: true))
                                {
                                    outputFile.Write($"{entry._date}|{entry._prompt}|{entry._entry}~");
                                }
                            }
                        break;
                        case 3: // Cancel save
                            Console.WriteLine("Save cancelled");
                            break;

                    }
                    validOption = true;
                }
                // If user input was invalid
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    validOption = false;
                }
            } while (validOption == false);
        }
        // If the file provided does not already exist
        else
        {
            foreach (Journal entry in _entries)
            {
                using (StreamWriter outputFile = new StreamWriter(_file))
                {
                    outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._entry}~");
                }
            }
        }


            
    }

    public Archive LoadEntries(string fileName)
    {
        Archive loadedJournal = new Archive();
        loadedJournal._file = fileName;
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] rawEntry = line.Split("~");
            foreach (string entryString in rawEntry)
            {
                Journal entry = new Journal();
                string[] parsedString = entryString.Split("|");
                if(parsedString[0] != "")
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
    public Archive LoadJournal(string fileName)
    {
        Archive loadedJournal = new Archive();
        loadedJournal = loadedJournal.LoadEntries(fileName);
        return loadedJournal;
    }
}