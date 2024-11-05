class Breathing : Activity
{
    private int _breathTime; // Length of each breath in seconds

    public Breathing()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Start()
    {
        StartMessage(_name, _description);
        _duration = GetDuration();
        _breathTime = GetBreathTime(_duration);
        Prepare();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\x1B[1mBreathe in... ");
            Pause(_breathTime, true, false);
            Console.Write("\nNow breathe out... \x1B[0m");
            Pause(_breathTime, true, false);
            Console.WriteLine("\n");
        }

        EndingMessage(_name, _duration);
    }

    public int GetBreathTime(int duration)
    {
        int breathCount = duration / 6; // 6 is the target breath length
        if (breathCount == 0)
        {
            breathCount = 1;
        }
        int breathDuration = duration / breathCount; // Gets as close to 6 seconds as possible
        if (breathDuration > 6)
        {
            breathDuration -= 5;
        }
        if (breathDuration < 4)
        {
            breathDuration += 2;
        }
        if (breathDuration >= 6 && breathCount == 1)
        {
            breathDuration /= 2;
        }
        return breathDuration;
    }
}