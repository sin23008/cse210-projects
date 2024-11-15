public class SimpleGoal : Goal
{
    public SimpleGoal() { 

    }
    public SimpleGoal(string name, string description, int points)
    { 
        _goalType = "Simple";
        _name = name;
        _description = description;
        _pointValue = points;
    }

    public override Goal PromptGoalInfo()
    {
        Console.WriteLine("What is the name of your Simple Goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal?");
        string description = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        int points = int.Parse(Console.ReadLine());

        Goal simpleGoal = new SimpleGoal(name, description, points);
        return simpleGoal;
    }

    public override void CompleteGoal()
    {
        _completionCheckmark = "[X]";
    }
}