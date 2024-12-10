class Program
{
    static async void Main(string[] args)
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
                    Console.WriteLine("Do you want to list open tickets (1) or all tickets (2)?");
                    string listChoice = Console.ReadLine();
                    switch (listChoice)
                    {
                        case "1":
                            Storage.ViewOpenTickets();
                            break;
                        case "2":
                            Storage.ViewAllTickets();
                            break;
                    }
                    break;
                case "A1":
                    Console.WriteLine("What is the asset tag of the asset you want to find?");
                    int assetTag = int.Parse(Console.ReadLine());
                    Asset asset = Storage.GetAssetById(assetTag);
                    asset.ViewHistory();
                    break;
                case "A2":
                    Console.WriteLine("What is the asset tag of the asset you want to update?");
                    assetTag = int.Parse(Console.ReadLine());
                    asset = Storage.GetAssetById(assetTag);
                    asset.Update();
                    Thread.Sleep(1000);
                    break;
                case "A3":
                    Console.WriteLine("Create a new asset");
                    Thread.Sleep(1000);
                    break;
                case "A4":
                    Console.WriteLine("List all assets");
                    Thread.Sleep(1000);
                    break;
                case "P1":
                    Console.WriteLine("Find a person");
                    Thread.Sleep(1000);
                    break;
                case "P2":
                    Console.WriteLine("Edit a person");
                    Thread.Sleep(1000);
                    break;
                case "P3":
                    Console.WriteLine("Create a person");
                    Thread.Sleep(1000);
                    break;
                case "P4":
                    Console.WriteLine("List all people");
                    Thread.Sleep(1000);
                    break;
                case "EXIT":
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