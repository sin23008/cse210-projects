class Listing : Activity
{
    private List<string> _prompts = 
    [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];
    private int _responseCount;

    public Listing()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _responseCount = 0;
    }

    public void Start()
    {
        StartMessage(_name, _description);
        _duration = GetDuration();
        Prepare();
        ShowPrompt();
        CountResponses();
        EndingMessage(_name, _duration);

    }
    public void ShowPrompt()
    {
        Random random = new();
        string prompt = _prompts[random.Next(_prompts.Count())];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\x1B[1m--- {prompt} ---\x1B[0m");
        Console.Write("You may begin in ");
        Pause(3, true, false);
        Console.Clear();
        Console.WriteLine($"\x1B[1m--- {prompt} ---\n\x1B[0m");
    }
    public void CountResponses()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _responseCount++;
        }
        Console.WriteLine($"\nYou listed {_responseCount} items!\n");
    }
}