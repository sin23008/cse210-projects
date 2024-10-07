public class Journal
{
    // attributes
    public string _date;
    public string _prompt;
    public string _entry;

    // methods
    public void show(Journal entry)
    {
        Console.WriteLine($"({entry._date})| {entry._prompt}");
        Console.WriteLine($"{entry._entry}");
    }
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
        this._prompt = SelectPrompt();

        Console.WriteLine(this._prompt);
        this._entry = Console.ReadLine();

        DateTime currentDateTime = DateTime.Now;
        this._date = currentDateTime.ToShortDateString();

        currentJournal._entries.Add(this);
    }
}