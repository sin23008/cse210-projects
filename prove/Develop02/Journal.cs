public class Journal
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
    public void WriteJournal(Archive currentJournal)
    {
        this._prompt = SelectPrompt(); // Generate prompt for entry

        Console.WriteLine(this._prompt);
        this._entry = Console.ReadLine();

        DateTime currentDateTime = DateTime.Now; // Record date of entry at time of entry
        this._date = currentDateTime.ToShortDateString();

        currentJournal._entries.Add(this); // Add entry to current journal
    }
}