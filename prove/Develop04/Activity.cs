class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected void StartMessage(string name, string description, int menuDelay)
    {
        Console.WriteLine($"Welcom to the {name} Activity\n\n");
        Console.WriteLine();
    }
    protected void Pause(int duration, bool doCountdown, bool doAnimation)
    {

    }
    protected int GetDuration()
    {
        return 0;
    }
    protected void EndingMessage(string activity, int duration, int menuDelay)
    {
        
    }
}