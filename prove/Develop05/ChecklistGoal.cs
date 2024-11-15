public class ChecklistGoal : Goal
{
    int _completionGoal;
    int _bonus;

    public ChecklistGoal()
    {

    }
    public ChecklistGoal(string name, string description, int points, int completionCount, int completionGoal, int bonus)
    { 
        _goalType = "Checklist";
        _name = name;
        _description = description;
        _pointValue = points;
        _completionCount = completionCount;
        _completionGoal = completionGoal;
        _bonus = bonus;
    }

    public override Goal PromptGoalInfo()
    {
        Console.WriteLine("What is the name of your Checklist Goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal?");
        string description = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("How many times must this goal be completed for a bonus?");
        int completionGoal = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the bonus for completing the goal that many times?");
        int bonus = int.Parse(Console.ReadLine());

        Goal eternalGoal = new ChecklistGoal(name, description, points, 0, completionGoal, bonus);
        return eternalGoal;
    }

    public override void CompleteGoal()
    {
        _completionCount++;
        if (_completionCount >= _completionGoal)
        {
            _completionCheckmark = "[X]";
        }
    }

    public override int GetCompletionGoal()
    {
        return _completionGoal;
    }

    public override int GetPointValue()
    {
        if (_completionCount >= _completionGoal)
        {
            return _pointValue + _bonus;
        }
        else
        {
            return _pointValue;
        }
    }

    public override int GetBonus()
    {
        return _bonus;
    }
}