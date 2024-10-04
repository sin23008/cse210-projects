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
}