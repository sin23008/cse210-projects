public class EternalGoal : Goal
{

    public EternalGoal() 
    { 

    }
    public EternalGoal(string name, string description, int pointValue)
    {
        _goalType = "Eternal";
        _name = name;
        _description = description;
        _pointValue = pointValue;
        _completionCount = 0;
    }

    public override Goal PromptGoalInfo()
    {
        Console.WriteLine("What is the name of your Eternal Goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal?");
        string description = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        int points = int.Parse(Console.ReadLine());

        Goal eternalGoal = new EternalGoal(name, description, points);
        return eternalGoal;
    }

    public override void CompleteGoal()
    {
        _completionCount++;
        _completionCheckmark = $"[{_completionCount}]";
        Console.WriteLine($"You have completed your Eternal Goal for the {_completionCount} time!");
    }

    public override string GetCompletionStatus()
    {
        return $"{_completionCheckmark}";
    }

    public void SetCompletionCount(int count)
    {
        _completionCount = count;
    }
}