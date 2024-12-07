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
}