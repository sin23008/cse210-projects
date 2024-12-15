class Program
{
    static void Main(string[] args)
    {
        bool doLoop = true;

        while (doLoop)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("Tickets:");
            Console.WriteLine("   T1. Find a ticket");
            Console.WriteLine("   T2. Update a ticket");
            Console.WriteLine("   T3. Create a new ticket");
            Console.WriteLine("   T4. List all tickets");
            Console.WriteLine("Assets:");
            Console.WriteLine("   A1. Find an asset");
            Console.WriteLine("   A2. Edit an asset");
            Console.WriteLine("   A3. Create a new asset");
            Console.WriteLine("   A4. List all assets");
            Console.WriteLine("People:");
            Console.WriteLine("   P1. Find a person");
            Console.WriteLine("   P2. Edit a person");
            Console.WriteLine("   P3. Create a person");
            Console.WriteLine("   P4. List all people");
            Console.WriteLine("Q. Quit");
            Console.Write("Select a choice from the menu: ");
            string selection = Console.ReadLine();
            Console.WriteLine();

            switch (selection.ToUpper())
            {
                case "T1":
                    Console.WriteLine("What is the ticket ID of the ticket you want to find?");
                    int ticketId = int.Parse(Console.ReadLine());
                    Ticket ticket = Storage.GetTicketById(ticketId);
                    ticket.DisplayHistory();
                    Storage.AwaitInput();
                    break;
                case "T2":
                    Console.WriteLine("What is the ticket ID of the ticket you want to update?");
                    ticketId = int.Parse(Console.ReadLine());
                    ticket = Storage.GetTicketById(ticketId);
                    ticket.Update();
                    break;
                case "T3":
                    Storage.CreateTicket();
                    break;
                case "T4":
                    Console.WriteLine("Do you want to list (1) open tickets, (2) all tickets, or (3) cards?");
                    string listChoice = Console.ReadLine();
                    switch (listChoice)
                    {
                        case "1":
                            Storage.ViewOpenTickets();
                            break;
                        case "2":
                            Storage.ViewAllTickets();
                            break;
                        case "3":
                            Storage.ViewAllCards();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                case "A1":
                    Console.WriteLine("What is the asset tag of the asset you want to find?");
                    int assetTag = int.Parse(Console.ReadLine());
                    Asset asset = Storage.GetAssetById(assetTag);
                    asset.Display();
                    asset.ViewHistory();
                    break;
                case "A2":
                    Console.WriteLine("What is the asset tag of the asset you want to update?");
                    assetTag = int.Parse(Console.ReadLine());
                    asset = Storage.GetAssetById(assetTag);
                    asset.Update();
                    Storage.AwaitInput();
                    break;
                case "A3":
                    Storage.CreateAsset();
                    break;
                case "A4":
                    Console.WriteLine("Do you want to list (1) current assets, (2) trickle assets, (3) or all assets?");
                    listChoice = Console.ReadLine();
                    switch (listChoice)
                    {
                        case "1":
                            Storage.ViewCurrentAssets();
                            break;
                        case "2":
                            Storage.ViewTrickleAssets();
                            break;
                        case "3":
                            Storage.ViewAllAssets();
                            break;
                    }
                    break;
                case "P1":
                    Console.WriteLine("Who is the person you want to find?");
                    string name = Console.ReadLine();
                    Employee employee = Storage.GetEmployeeByName(name);
                    employee.ViewInfo();
                    Console.WriteLine("What do you want to view about this person? ((1)History, (2)Assets, (3)Tickets)");
                    string viewChoice = Console.ReadLine();
                    switch (viewChoice)
                    {
                        case "1":
                            employee.ViewHistory();
                            Storage.AwaitInput();
                            break;
                        case "2":
                            employee.ViewAssets();
                            Storage.AwaitInput();
                            break;
                        case "3":
                            employee.ViewTickets();
                            Storage.AwaitInput();
                            break;
                    }
                    break;
                case "P2":
                    Console.WriteLine("Who do you want to edit?");
                    name = Console.ReadLine();
                    employee = Storage.GetEmployeeByName(name);
                    employee.Update();
                    break;
                case "P3":
                    Storage.CreateEmployee();
                    break;
                case "P4":
                    Console.WriteLine("Do you want to list (1)full time employees, (2)part time employees, or (3)all employees?");
                    listChoice = Console.ReadLine();
                    switch (listChoice)
                    {
                        case "1":
                            Storage.ViewFullTimeEmployees();
                            break;
                        case "2":
                            Storage.ViewPartTimeEmployees();
                            break;
                        case "3":
                            Storage.ViewAllEmployees();
                            break;
                        default:
                            Console.WriteLine("\nInvalid selection\n");
                            Thread.Sleep(1000);
                            break;
                    }
                    break;
                case "EXIT" or "QUIT" or "E" or "Q":
                    doLoop = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid selection\n");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}