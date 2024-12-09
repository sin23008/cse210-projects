abstract class Employee
{
    protected string _name;
    protected string _email;
    protected string _role;
    protected List<string> _history;
    protected bool _isCurrentEmployee = true;

    public Employee(string name, string email, string role)
    {
        _history = new List<string>();
        _name = name;
        _history.Add($"Name set to {_name}");
        _email = email;
        _history.Add($"Email set to {_email}");
        _role = role;
        _history.Add($"Role set to {_role}");

    }

    public void ChangeRole(string newRole)
    {
        _history.Add($"Role changed from {_role} to {newRole}");
        _role = newRole;
    }

    public void ViewInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Email: {_email}");
        Console.WriteLine($"Role: {_role}");
    }

    public void ViewHistory()
    {
        foreach (string entry in _history)
        {
            Console.WriteLine(entry);
        }
    }

    public string GetName()
    {
        return _name;
    }
}