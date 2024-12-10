abstract class Asset
{
    protected int _assetTag;
    protected string _deviceType;
    protected int _aquisitionYear;
    protected (string, string) _location;
    protected Employee _owner;
    protected bool _isTrickle;
    protected List<int> _tickets;
    protected List<string> _history;

    public Asset(int assetTag, string deviceType)
    {
        _assetTag = assetTag;
        _deviceType = deviceType;
        _aquisitionYear = 0;
        _location = ("", "");
        _owner = null;
        _isTrickle = false;
        _tickets = new List<int>();
    }

    public void TransferOwnership(Employee newOwner)
    {
        _history.Add($"Transferred ownership from {_owner.GetName()} to {newOwner.GetName()}");
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

    public void Display()
    {
        Console.WriteLine($"Asset ID: {_assetTag}");
        Console.WriteLine($"   Device Type: {_deviceType}");
        Console.WriteLine($"   Aquisition Year: {_aquisitionYear}");
        Console.WriteLine($"   Location: {_location.Item1}, {_location.Item2}");
        Console.WriteLine($"   Owner: {_owner.GetName()}");
        Console.WriteLine($"   Trickle: {_isTrickle}");
    }

    public void Update()
    {
        Console.WriteLine("What do you want to update? (location, owner, type, isTrickle)");
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
                _history.Add($"Owner changed from {_owner.GetName()} to {newOwner.GetName()}");
                _owner = newOwner;
                break;
            case "type":
                Console.WriteLine("What is the new device type?");
                string newDeviceType = Console.ReadLine();
                _history.Add($"Device type changed from {_deviceType} to {newDeviceType}");
                _deviceType = newDeviceType;
                break;
            case "isTrickle":
                _history.Add($"Trickle status changed from {_isTrickle} to {!_isTrickle}");
                _isTrickle = !_isTrickle;
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}