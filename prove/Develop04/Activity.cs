class Activity
{
    protected string _name; // Activity name
    protected string _description; // Activity description
    protected int _duration; // Length of time in milliseconds

    protected void StartMessage(string name, string description)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {name} Activity\n");
        Console.WriteLine($"{description}\n");

    }
    protected void Pause(int duration, bool doCountdown, bool doAnimation)
    {
        if (doCountdown && doAnimation)
        {
            Console.WriteLine("\x1B[1;31mCannot perform both countdown and animation simultaneously\x1B[0m");
        }

        if (doCountdown)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        else if (doAnimation)
        {
            List<string> animationElements = ["|", "/", "-", "\\"];

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            while (DateTime.Now < endTime)
            {
                foreach (string s in animationElements)
                {
                    Console.Write(s);
                    Thread.Sleep(100);
                    Console.Write("\b \b");
                }
            }
        }
        else
        {
            Thread.Sleep(duration * 1000);
        }
    }
    protected int GetDuration()
    {
        while (true)
        {
            Console.WriteLine("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int duration))
            {
                return duration;
            }
            else
            {
                Console.WriteLine("\x1B[1;31mInvalid input. Please try again.\x1B[0m\n");
            }
        }
    }
    protected void Prepare()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Pause(3, false, true);
        Console.WriteLine("\n");
    }
    protected void EndingMessage(string activity, int duration)
    {
        Console.WriteLine("Well done!");
        Pause(3, false, true);
        Console.WriteLine($"\nYou have completed another {duration} seconds of the {activity} Activity.");
        Pause(7, false, true);
        Console.Clear();
    }
}