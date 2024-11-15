public class GoalTracker
{
    private string _userName;
    private List<Goal> _goals = new List<Goal>();

    private int _points = 0;

    public void Startup()
    {
        Console.WriteLine("Welcome to the Goal Tracker!");
        Console.WriteLine("Do you want to (1)load your goals from a file or (2)start a new set of goals?");
        string selection = Console.ReadLine();
        if (selection == "1")
        {
            LoadGoals();
        }
        else
        {
            Console.WriteLine("What is your name?");
            _userName = Console.ReadLine();
            Console.WriteLine($"Welcome, {_userName}!");
        }
    }

    public int GetPoints()
    {
        return _points;
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create?");
        string goalType = Console.ReadLine();
        switch (goalType)
        {
            case "1":
                Goal simpleGoal = new SimpleGoal();
                simpleGoal = simpleGoal.PromptGoalInfo();
                _goals.Add(simpleGoal);
                break;
            case "2":
                Goal eternalGoal = new EternalGoal();
                eternalGoal = eternalGoal.PromptGoalInfo();
                _goals.Add(eternalGoal);
                break;
            case "3":
                Goal checklistGoal = new ChecklistGoal();
                checklistGoal = checklistGoal.PromptGoalInfo();
                _goals.Add(checklistGoal);
                break;
        }
    }

    public void DisplayGoals()
    {
        int goalCount = 1;
        Console.WriteLine("\nYour current goals:");
        foreach (Goal goal in _goals)
        {
            if (goal.GetGoalType() == "Checklist")
            {
                Console.WriteLine($"{goalCount}. {goal.GetCompletionStatus()} {goal.GetName()} ({goal.GetDescription()}) {goal.GetCompletionCount()} / {goal.GetCompletionGoal()}");
            }
            else 
            {
                Console.WriteLine($"{goalCount}. {goal.GetCompletionStatus()} {goal.GetName()} ({goal.GetDescription()})");
            }
            goalCount++;
        }
    }

    public void PromptSave()
    {
        Console.WriteLine("What file would you like to save your goals to?");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
        {
            Console.WriteLine("File already exists. Do you want to overwrite it?");
            if (new[] {"yes", "y"}.Contains(Console.ReadLine().ToLower()))
            {
                File.Delete(fileName);
                SaveGoals(fileName);
            }
            else
            {
                Console.WriteLine("File not saved.");
            }
        }
        else
        {
            SaveGoals(fileName);
        }
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {
            outputFile.WriteLine($"{_userName}");
            outputFile.WriteLine($"{_points}");
            foreach (Goal goal in _goals)
            {
                switch (goal.GetGoalType())
                {
                    case "Simple":
                        outputFile.WriteLine($"{goal.GetGoalType()}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointValue()}|{goal.GetCompletionStatus()}");
                        break;
                    case "Eternal":
                        outputFile.WriteLine($"{goal.GetGoalType()}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointValue()}|{goal.GetCompletionCount()}|{goal.GetCompletionStatus()}");
                        break;
                    case "Checklist":
                        outputFile.WriteLine($"{goal.GetGoalType()}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointValue()}|{goal.GetCompletionCount()}|{goal.GetCompletionGoal()}|{goal.GetBonus()}|{goal.GetCompletionStatus()}");
                        break;
                }
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat file would you like to load your goals from? ");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            _userName = lines[0];
            _points = int.Parse(lines[1]);
            for (int i = 2; i < lines.Length; i++)
            {
                string[] goalInfo = lines[i].Split('|');
                switch (goalInfo[0])
                {
                    case "Simple":
                        SimpleGoal simpleGoal = new SimpleGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]));
                        simpleGoal.SetCompletionStatus(goalInfo[4]);
                        _goals.Add(simpleGoal);
                        break;
                    case "Eternal":
                        EternalGoal eternalGoal = new EternalGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]));
                        eternalGoal.SetCompletionCount(int.Parse(goalInfo[4]));
                        eternalGoal.SetCompletionStatus(goalInfo[5]);
                        _goals.Add(eternalGoal);
                        break;
                    case "Checklist":
                        ChecklistGoal checklistGoal = new ChecklistGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), int.Parse(goalInfo[4]), int.Parse(goalInfo[5]), int.Parse(goalInfo[6]));
                        checklistGoal.SetCompletionStatus(goalInfo[7]);
                        _goals.Add(checklistGoal);
                        break;
                }
            }
            Console.WriteLine("Goals loaded.\n");
            Console.WriteLine($"Welcome back, {_userName}!");
        }
        else
        {
            Console.WriteLine("File not found. Unable to load goals.");
        }
    }

    public void RecordProgress()
    {
        DisplayGoals();
        Console.WriteLine("Which goal would you like to record progress for?");
        int goalNumber = int.Parse(Console.ReadLine());
        Goal selectedGoal = _goals[goalNumber - 1];
        string goalType = selectedGoal.GetGoalType();
        switch (goalType)
        {
            case "Simple":
                selectedGoal.CompleteGoal();
                _points += selectedGoal.GetPointValue();
                break;
            case "Eternal":
                selectedGoal.CompleteGoal();
                _points += selectedGoal.GetPointValue();
                break;
            case "Checklist":
                selectedGoal.CompleteGoal();
                _points += selectedGoal.GetPointValue();
                break;
        }
        Console.WriteLine($"Congratulations! You have earned {selectedGoal.GetPointValue()} points!");
        Console.WriteLine($"You now have {_points} points.");
    }
}