class Storage
{
    private List<Asset> _assets = new List<Asset>();
    private List<Employee> _employees = new List<Employee>();
    private List<Ticket> _tickets = new List<Ticket>();

// T1 Find a ticket
    public Ticket GetTicketById(int id)
    {
        foreach (Ticket ticket in _tickets)
        {
            if (ticket._ticketId == id)
            {
                return ticket;
            }
        }
        return null;
    }

// T2 Update a ticket
    // Find ticket by ID, then use ticket.update()
    public void UpdateTicket(Ticket ticket) {}
// T3 Create a new ticket
    public void CreateTicket()
    {
        
    }

// T4 List tickets
    public void ViewOpenTickets()
    {
        foreach (Ticket ticket in _tickets)
        {
            if (ticket._status != "Closed" && ticket._status != "Resolved")
            {
                ticket.Display();
            }
        }
    }

    public void ViewAllTickets()
    {
        foreach (Ticket ticket in _tickets)
        {
            ticket.Display();
        }
    }

// A1 Find an asset
    public Asset GetAssetById(int id)
    {
        foreach (Asset asset in _assets)
        {
            if (asset.GetAssetTag() == id)
            {
                return asset;
            }
        }
        return null;
    }
// A2 Update an asset
    // Find asset by ID, then use one of the 
// A3 Create a new asset
    public void CreateAsset(int assetTag, string deviceType)
    {
        Asset asset = new CurrentAsset(assetTag, deviceType);
        _assets.Add(asset);
    }
// A4 List assets
    public void ViewAllAssets()
    {
        foreach (Asset asset in _assets)
        {
            asset.Display();
        }
    }
// P1 Find a person
    public Employee GetEmployeeByName(string name)
    {
        foreach (Employee employee in _employees)
        {
            if (employee.GetName() == name)
            {
                return employee;
            }
        }
        return null;
    }
// P2 Edit a person

// P3 Create a person
    public void CreateEmployee()
    {
        Console.WriteLine("What is the employee's name?");
        string name = Console.ReadLine();
        Console.WriteLine("What is their email?");
        string email = Console.ReadLine();
        Console.WriteLine("What is their role?");
        string role = Console.ReadLine();
        Console.WriteLine("Is this a full time employee? (y/n)");
        string answer = Console.ReadLine();
        switch (answer.ToLower())
        {
            case "y":
                _employees.Add(new FullTime(name, email, role));
                break;
            case "n":
                Console.WriteLine("Who is their supervisor?");
                string supervisorName = Console.ReadLine();
                // Look up supervisor, then add to the employee
                FullTime supervisor = new FullTime(name, email, role); // Placeholder
                _employees.Add(new PartTime(name, email, role, supervisor));
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }

// P4 List people

}