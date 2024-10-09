 public class Entry
{
    // attributes
    public string _date;
    public string _prompt;
    public string _entry;

    // methods
    static string SelectPrompt()
    {
        Random random = new();
        List<string> prompts = ["Prompt1", "Prompt2", "Prompt3"];
        int promptIndex = random.Next(prompts.Count);
        string prompt = prompts[promptIndex];
        return prompt;
    }
    public void WriteJournal(Journal currentJournal)
    {
        Entry entry = new();
        entry._prompt = SelectPrompt(); // Generate prompt for entry

        Console.WriteLine(entry._prompt);
        entry._entry = Console.ReadLine();

        DateTime currentDateTime = DateTime.Now; // Record date of entry at time of entry
        entry._date = currentDateTime.ToShortDateString();

        currentJournal._entries.Add(entry); // Add entry to current journal
    }
}