static class Storage
{
    private static List<Asset> _assets = new List<Asset>();
    private static List<Employee> _employees = new List<Employee>();
    private static List<Ticket> _tickets = new List<Ticket>();
    private static int _ticketCount = 1000;
    private static int _cardCount = 0;
    private static int _assetCount = 0;

// T1 Find a ticket
    public static Ticket GetTicketById(int id)
    {
        foreach (Ticket ticket in _tickets)
        {
            if (ticket.GetTicketId() == id)
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
        requestorName = requestor.GetName();
        Ticket ticket = new Ticket(_ticketCount, title, description, priority, requestorName);
        _tickets.Add(ticket);
        requestor.AddTicket(ticket.GetTicketId());
        Console.WriteLine($"Ticket {ticket.GetTicketId()} created.");
        AwaitInput();
    }

    public static void CreateCard()
    {
        _cardCount++;
        Console.WriteLine("What is the requestor of the card?");
        string requestorName = Console.ReadLine();
        Employee requestor = GetEmployeeByName(requestorName);
        requestorName = requestor.GetName();
        Console.WriteLine("What is the new asset type?");
        string newAssetType = Console.ReadLine();
        Console.WriteLine("What is the old asset?");
        int oldAssetID = int.Parse(Console.ReadLine());
        Asset oldAsset = GetAssetById(oldAssetID);
        Card card = new(_cardCount, requestorName, newAssetType, oldAssetID);
        _tickets.Add(card);
        oldAsset.AddTicket(card.GetTicketId());
        requestor.AddTicket(card.GetTicketId());
        Console.WriteLine($"Card {card.GetTicketId()} created.");
    }

// T4 List tickets
    public static void ViewOpenTickets()
    {
        foreach (Ticket ticket in _tickets)
        {
            if (ticket.GetStatus() != "Closed" && ticket.GetStatus() != "Resolved" && ticket is not Card)
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
            if (ticket is not Card)
            {
                ticket.DisplayOverview();
            }
        }
        AwaitInput();
    }
    public static void ViewAllCards()
    {
        foreach (Card ticket in _tickets)
        {
            if (ticket is Card)
            {
                ticket.Display();
            }
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
    public static void MakeTrickle(int id)
    {
        Asset asset = GetAssetById(id);
        Console.WriteLine($"What year was this made a trickle asset?");
        int year = int.Parse(Console.ReadLine());
        new TrickleAsset(id, asset.GetDeviceType(), year);
        int assetIndex = _assets.IndexOf(asset);
        _assets[assetIndex] = new TrickleAsset(id, asset.GetDeviceType(), year);
        Console.WriteLine($"Asset {id} updated.");
    }
// A3 Create a new asset
    public static void CreateAsset()
    {
        _assetCount++;
        Console.WriteLine("What is the device type?");
        string deviceType = Console.ReadLine();
        int assetTag = _assetCount;
        Asset asset = new CurrentAsset(assetTag, deviceType);
        Console.WriteLine("Who is the owner of this asset? (Leave blank for no owner)");
        string ownerName = Console.ReadLine();
        asset.SetOwner(ownerName);
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
    public static void ViewCurrentAssets()
    {
        foreach (Asset asset in _assets)
        {
            if (asset is CurrentAsset)
            {
                asset.Display();
            }
        }
        AwaitInput();
    }
    public static void ViewTrickleAssets()
    {
        foreach (Asset asset in _assets)
        {
            if (asset is TrickleAsset)
            {
                asset.Display();
            }
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
                if (employee.GetName() == name || employee.GetName().ToLower() == name.ToLower())
                {
                    return employee;
                }
            }
            Console.WriteLine("Employee not found. Try again? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                Console.WriteLine("What is the employee's name?");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Returning blank employee.");
                return new FullTime();
            }
        }
    }
// P2 Edit a person
    // Defined in program
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
                supervisorName = GetEmployeeByName(supervisorName).GetName();
                _employees.Add(new PartTime(name, email, role, supervisorName));
                Console.WriteLine("Part time employee added.");
                AwaitInput();
                break;
            default:
                Console.WriteLine("Invalid input");
                AwaitInput();
                break;
        }
    }

// P4 List people
    public static void ViewAllEmployees()
    {
        foreach (Employee employee in _employees)
        {
            employee.ViewInfo();
            Console.WriteLine();
        }
        AwaitInput();
    }
    public static void ViewFullTimeEmployees()
    {
        foreach (Employee employee in _employees)
        {
            if (employee is FullTime)
            {
                employee.ViewInfo();
                Console.WriteLine();
            }
        }
        AwaitInput();
    }
    public static void ViewPartTimeEmployees()
    {
        foreach (Employee employee in _employees)
        {
            if (employee is PartTime)
            {
                employee.ViewInfo();
                Console.WriteLine();
            }
        }
        AwaitInput();
    }

    public static void AwaitInput()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}