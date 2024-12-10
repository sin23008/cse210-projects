using System.Diagnostics.Contracts;

class Ticket
{
    public int _ticketId;
    public string _title;
    public string _description;
    public string _status;
    public string _priority;
    public Employee _requestor;
    private List<string> _history;
    private int _commentCount;
    private int _updateCount;

    public Ticket(int id, string title, Employee requestor) // used for card creation
    {
        _ticketId = id;
        _title = title;
        _requestor = requestor;
    }
    public Ticket(int id, string title, string description, string priority, Employee requestor)
    {
        _history = new List<string>();
        _ticketId = id;
        _title = title;
        _description = description;
        _priority = priority;
        _requestor = requestor;
        _status = "New";
    }

    public void ChangeStatus(string status)
    {
        switch (status.ToLower())
        {
            case "new":
                _history.Add($"Status changed from {_status} to New");
                _status = "New";
                break;
            case "working":
                _history.Add($"Status changed from {_status} to Working");
                _status = "Working";
                break;
            case "waiting":
                _history.Add($"Status changed from {_status} to Waiting");
                _status = "Waiting";
                break;
            case "resolved":
                _history.Add($"Status changed from {_status} to Resolved");
                _status = "Resolved";
                break;
            case "closed":
                _history.Add($"Status changed from {_status} to Closed");
                _status = "Closed";
                break;
            default:
                Console.WriteLine("Invalid status");
                break;
        }
    }

    public void Update()
    {
        Console.WriteLine("What do you want to update? (title, description, priority, requestor, add comment)");
        string field = Console.ReadLine();
        switch (field.ToLower())
        {
            case "title":
                Console.WriteLine("What is the new title?");
                string newTitle = Console.ReadLine();
                _history.Add($"Title changed from {_title} to {newTitle}");
                _title = newTitle;
                break;
            case "description":
                Console.WriteLine("What is the new description?");
                string newDescription = Console.ReadLine();
                _history.Add($"Description changed from {_description} to {newDescription}");
                _description = newDescription;
                break;
            case "priority":
                Console.WriteLine("What is the new priority?");
                string newPriority = Console.ReadLine();
                _history.Add($"Priority changed from {_priority} to {newPriority}");
                _priority = newPriority;
                break;
            case "requestor":
                Console.WriteLine("Who is the new requestor?");
                string newRequestorName = Console.ReadLine();
                Employee newRequestor = Storage.GetEmployeeByName(newRequestorName);
                _history.Add($"Requestor changed from {_requestor} to {newRequestor.GetName()}");
                _requestor = newRequestor;
                break;
            case "add comment":
                Console.WriteLine("What is the comment?");
                string comment = Console.ReadLine();
                _history.Add($"Comment added: {comment}");
                _commentCount++;
                break;
            default:
                Console.WriteLine("Invalid field");
                break;
        }

        Console.WriteLine("Change status?");
        string doChange = Console.ReadLine();
        if (doChange.ToLower() == "yes" || doChange.ToLower() == "y")
        {
            Console.WriteLine("What is the new status? (New, Working, Waiting, Resolved, Closed)");
            string status = Console.ReadLine();
            ChangeStatus(status);
        }
        Console.WriteLine("Update complete");
        Storage.AwaitInput();
    }

    public void DisplayOverview()
    {
        Console.WriteLine($"Ticket ID: {_ticketId}");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Priority: {_priority}");
        Console.WriteLine($"Requestor: {_requestor}");
        Console.WriteLine($"Status: {_status}");
        Console.WriteLine($"Comment count: {_commentCount}");
        Console.WriteLine($"Update count: {_updateCount}");
    }

    public void DisplayHistory()
    {
        DisplayOverview();
        Console.WriteLine("--===========================--");
        foreach (string entry in _history)
        {
            Console.WriteLine(entry);
        }
    }

    public int GetTicketId()
    {
        return _ticketId;
    }
}