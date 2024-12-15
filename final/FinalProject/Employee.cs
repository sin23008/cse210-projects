abstract class Employee
{
    protected string _name;
    protected string _email;
    protected string _role;
    protected List<string> _history = new List<string>();
    protected bool _isCurrentEmployee = true;
    protected List<(int, string)> _tickets = new List<(int, string)>();

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

    public Employee()
    {
        _name = "Unassigned";  
        _email = "Unassigned";
        _role = "Unassigned";
    }

    public void ChangeRole(string newRole)
    {
        _history.Add($"Role changed from {_role} to {newRole}");
        _role = newRole;
    }

    public virtual void ViewInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Email: {_email}");
        if (_isCurrentEmployee)
        {
            Console.WriteLine($"Role: {_role}");
        }
        else
        {
            Console.WriteLine("Role: Terminated");
        }
    }

    public void ViewHistory()
    {
        foreach (string entry in _history)
        {
            Console.WriteLine(entry);
        }
    }

    public abstract void ViewAssets();

    public void ViewTickets()
    {
        foreach ((int, string) ticket in _tickets)
        {
            Console.WriteLine(ticket.Item1 + " - " + ticket.Item2);
        }
    }

    public string GetName()
    {
        return _name;
    }

    public void AddTicket(int ticketId)
    {
        Ticket ticket = Storage.GetTicketById(ticketId);
        _tickets.Add((ticket.GetTicketId(), ticket.GetTitle()));
    }

    public void Terminate()
    {
        if (_isCurrentEmployee)
        {
            Console.WriteLine("Do you want to terminate this employee? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                _isCurrentEmployee = false;
                _history.Add("Terminated");
                Console.WriteLine("Employee terminated.");
                Storage.AwaitInput();
            }
        }
        else
        {
            Console.WriteLine("This employee is already terminated. Do you want to reactivate them? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                _isCurrentEmployee = true;
                _history.Add("Reactivated");
                Console.WriteLine("Employee reactivated.");
                Storage.AwaitInput();
            }
        }
    }

    public abstract void AddAsset(int asset);

    public abstract void Update();
}