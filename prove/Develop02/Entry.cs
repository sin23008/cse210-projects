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
        List<string> prompts = ["What was the best part of your day? Why did it stand out to you?",
                                "Did you face any challenges today? How did you handle them, and what could you have done differently?",
                                "How did you feel throughout the day? Did your mood change at any point? What influenced it?",
                                "What is one thing you accomplished today, big or small, that made you feel proud?",
                                "Who did you interact with today, and how did they impact your day—either positively or negatively",
                                "What is something you learned today, whether from an experience, a person, or even a random thought?",
                                "What is one thing from today that you are grateful for? How did it make your day better?"];
                                
        int promptIndex = random.Next(prompts.Count);
        string prompt = prompts[promptIndex];
        return prompt;
    }
    
    public void NewEntry(Journal currentJournal)
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