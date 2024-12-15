class TrickleAsset : Asset
{
    int _trickleYear;
    public TrickleAsset(int assetTag, string deviceType, int yearReplaced) : base(assetTag, deviceType)
    {
        _trickleYear = yearReplaced;
        _isTrickle = true;
    }

    public override void Display()
    {
        Console.WriteLine($"Asset ID: {_assetTag}");
        Console.WriteLine($"   Device Type: {_deviceType}");
        Console.WriteLine($"   Trickle");
        Console.WriteLine($"   Aquisition Year: {_aquisitionYear}");
        Console.WriteLine($"   Trickle Year: {_trickleYear}");
        Console.WriteLine($"   Location: {_location.Item1}, {_location.Item2}");
        Console.WriteLine($"   Owner: {_owner}");
    }
}