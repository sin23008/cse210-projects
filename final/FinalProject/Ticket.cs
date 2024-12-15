class Ticket
{
    protected int _ticketId;
    protected string _title;
    protected string _description;
    protected string _status;
    protected string _priority;
    protected string _requestor;
    protected List<int> _assets;
    protected List<string> _history;
    protected int _commentCount;
    protected int _updateCount;

    public Ticket(int id, string title, string requestor) // used for card creation
    {
        _ticketId = id;
        _title = title;
        _requestor = requestor;
    }
    public Ticket(int id, string title, string description, string priority, string requestor)
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
        Console.WriteLine("What do you want to update? (title, description, priority, requestor, comment, assets)");
        string field = Console.ReadLine();
        switch (field.ToLower())
        {
            case "title":
                Console.WriteLine("What is the new title?");
                string newTitle = Console.ReadLine();
                _history.Add($"Title changed from {_title} to {newTitle}");
                _title = newTitle;
                _updateCount++;
                break;
            case "description":
                Console.WriteLine("What is the new description?");
                string newDescription = Console.ReadLine();
                _history.Add($"Description changed from {_description} to {newDescription}");
                _description = newDescription;
                _updateCount++;
                break;
            case "priority":
                Console.WriteLine("What is the new priority?");
                string newPriority = Console.ReadLine();
                _history.Add($"Priority changed from {_priority} to {newPriority}");
                _priority = newPriority;
                _updateCount++;
                break;
            case "requestor":
                Console.WriteLine("Who is the new requestor?");
                string newRequestorName = Console.ReadLine();
                string newRequestor = Storage.GetEmployeeByName(newRequestorName).GetName();
                _history.Add($"Requestor changed from {_requestor} to {newRequestor}");
                _requestor = newRequestor;
                Storage.GetEmployeeByName(newRequestorName).AddTicket(_ticketId);
                _updateCount++;
                break;
            case "comment":
                Console.WriteLine("What is the comment?");
                string comment = Console.ReadLine();
                _history.Add($"Comment added: {comment}");
                _commentCount++;
                _updateCount++;
                break;
            case "assets":
                Console.WriteLine("What is the asset ID?");
                int assetId = int.Parse(Console.ReadLine());
                _history.Add($"Asset added: {assetId}");
                _assets.Add(assetId);
                _updateCount++;
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
        Console.WriteLine($"Assets:");
        foreach (int assetId in _assets)
        {
            Console.WriteLine($"  {assetId}");
        }
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

    public string GetTitle()
    {
        return _title;
    }

    public string GetStatus()
    {
        return _status;
    }
}