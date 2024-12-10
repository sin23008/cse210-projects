using System.Runtime.Intrinsics.Arm;

static class Storage
{
    private static List<Asset> _assets = new List<Asset>();
    private static List<Employee> _employees = new List<Employee>();
    private static List<Ticket> _tickets = new List<Ticket>();
    private static int _ticketCount = 1000;

// T1 Find a ticket
    public static Ticket GetTicketById(int id)
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

// T3 Create a new ticket
    public static void CreateTicket()
    {
        _ticketCount++;
        Console.WriteLine("What is the title of the ticket?");
        string title = Console.ReadLine();
        Console.WriteLine("What is the description of the ticket?");
        string description = Console.ReadLine();
        Console.WriteLine("What is the priority of the ticket? (Low, Medium, High)");
        string priority = Console.ReadLine();
        Console.WriteLine("Who is the requestor of the ticket?");
        string requestorName = Console.ReadLine();
        Employee requestor = GetEmployeeByName(requestorName);
        Ticket ticket = new Ticket(_ticketCount, title, description, priority, requestor);
        _tickets.Add(ticket);
        Console.WriteLine($"Ticket {ticket.GetTicketId()} created.");
        AwaitInput();
    }

// T4 List tickets
    public static void ViewOpenTickets()
    {
        foreach (Ticket ticket in _tickets)
        {
            if (ticket._status != "Closed" && ticket._status != "Resolved")
            {
                ticket.DisplayOverview();
            }
        }
        AwaitInput();
    }

    public static void ViewAllTickets()
    {
        foreach (Ticket ticket in _tickets)
        {
            ticket.DisplayOverview();
        }
        AwaitInput();
    }

// A1 Find an asset
    public static Asset GetAssetById(int id)
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
    // Defined in program

// A3 Create a new asset
    public static void CreateAsset(int assetTag, string deviceType)
    {
        Asset asset = new CurrentAsset(assetTag, deviceType);
        _assets.Add(asset);
        Console.WriteLine($"Asset {asset.GetAssetTag()} created.");
        AwaitInput();
    }
// A4 List assets
    public static void ViewAllAssets()
    {
        foreach (Asset asset in _assets)
        {
            asset.Display();
        }
        AwaitInput();
    }
// P1 Find a person
    public static Employee GetEmployeeByName(string name)
    {
        while (true)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.GetName() == name)
                {
                    return employee;
                }
            }
            Console.WriteLine("Employee not found. Try again? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "n")
            {
                return null;
            }
        }
    }
// P2 Edit a person

// P3 Create a person
    public static void CreateEmployee()
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
                Console.WriteLine("Full time employee added.");
                AwaitInput();
                break;
            case "n":
                Console.WriteLine("Who is their supervisor?");
                string supervisorName = Console.ReadLine();
                // Look up supervisor, then add to the employee
                FullTime supervisor = new FullTime(name, email, role); // Placeholder
                _employees.Add(new PartTime(name, email, role, supervisor));
                Console.WriteLine("Part time employee added.");
                AwaitInput();
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }

// P4 List people


    public static void AwaitInput()
    {
        Console.WriteLine("Press any key to continue...");
        Console.Read();
    }
}