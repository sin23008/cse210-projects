using System.Diagnostics.Contracts;

public abstract class Goal
{
    protected string _goalType;
    protected string _name;
    protected string _description;
    protected int _pointValue;
    protected string _completionCheckmark = "[ ]";
    protected int _completionCount;

    public string GetGoalType()
    {
        return _goalType;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual int GetPointValue()
    {
        return _pointValue;
    }

    public virtual string GetCompletionStatus()
    {
        return _completionCheckmark;
    }

    public abstract void CompleteGoal();

    public abstract Goal PromptGoalInfo();

    public virtual int GetCompletionGoal()
    {
        return 0;
    }

    public int GetCompletionCount()
    {
        return _completionCount;
    }

    public void SetCompletionStatus(string status)
    {
        _completionCheckmark = status;
    }

    public virtual int GetBonus()
    {
        return 0;
    }
}