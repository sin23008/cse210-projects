abstract class Asset
{
    protected int _assetTag;
    protected string _deviceType;
    protected int _aquisitionYear;
    protected (string, string) _location;
    protected string _owner;
    protected bool _isTrickle;
    protected List<int> _tickets;
    protected List<string> _history = new List<string>();

    public Asset(int assetTag, string deviceType)
    {
        _assetTag = assetTag;
        _deviceType = deviceType;
        _aquisitionYear = 0;
        _location = ("", "");
        _owner = "";
        _isTrickle = false;
        _tickets = new List<int>();
    }

    public void TransferOwnership(string newOwner)
    {
        string newOwnerName = Storage.GetEmployeeByName(newOwner).GetName();
        _history.Add($"Transferred ownership from {_owner} to {newOwner}");
        _owner = newOwner;
    }

    public void SetOwner(string owner)
    {
        if (owner == "")
        {
            _owner = "";
            return;
        }
        string newOwner = Storage.GetEmployeeByName(owner).GetName();
        _history.Add($"Transferred ownership from {_owner} to {newOwner}");
        _owner = newOwner;
    }

    public void ChangeLocation((string, string) location)
    {
        _history.Add($"Moved from {_location.Item1}, {_location.Item2} to {location.Item1}, {location.Item2}");
        _location = location;
    }

    public void ViewHistory()
    {
        foreach (string entry in _history)
        {
            Console.WriteLine(entry);
        }
        Storage.AwaitInput();
    }
    
    public int GetAssetTag()
    {
        return _assetTag;
    }

    public string GetDeviceType()
    {
        return _deviceType;
    }
    public abstract void Display();

    public void Update()
    {
        Console.WriteLine("What do you want to update? (location, owner, type, trickle, card)");
        string field = Console.ReadLine();
        switch (field.ToLower())
        {
            case "location":
                Console.WriteLine("What is the new Building?");
                string newBuilding = Console.ReadLine();
                Console.WriteLine("What is the new Room?");
                string newRoom = Console.ReadLine();
                (string, string)newLocation = (newBuilding, newRoom);
                _history.Add($"Location changed from {_location.Item1} {_location.Item2} to {newLocation.Item1} {newLocation.Item2}");
                _location = newLocation;
                break;
            case "owner":
                Console.WriteLine("Who is the new owner?");
                string newOwnerName = Console.ReadLine();
                Employee newOwner = Storage.GetEmployeeByName(newOwnerName);
                newOwnerName = newOwner.GetName();
                _history.Add($"Owner changed from {_owner} to {newOwner.GetName()}");
                _owner = newOwnerName;
                newOwner.AddAsset(_assetTag);
                break;
            case "type":
                Console.WriteLine("What is the new device type?");
                string newDeviceType = Console.ReadLine();
                _history.Add($"Device type changed from {_deviceType} to {newDeviceType}");
                _deviceType = newDeviceType;
                break;
            case "trickle":
                Storage.MakeTrickle(_assetTag);
                _history.Add($"Trickle status changed from {_isTrickle} to {!_isTrickle}");
                break;
            case "card":
                Storage.CreateCard();
                int ticketIndex = 0;
                if (_tickets.Count > 0)
                {
                    ticketIndex = _tickets.Count - 1;
                }
                _history.Add($"Card {_tickets[ticketIndex]} created for asset {_assetTag}");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }

    public void AddTicket(int ticketId)
    {
        _tickets.Add(ticketId);
    }
}