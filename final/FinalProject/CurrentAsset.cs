class CurrentAsset : Asset
{
    private int _replacementYear;
    public CurrentAsset(int assetTag, string deviceType) : base(assetTag, deviceType)
    {
        _replacementYear = _aquisitionYear + 4;
    }

    public void MakeCard()
    {
        Storage.CreateCard();
    }

    public override void Display()
    {
        Console.WriteLine($"Asset ID: {_assetTag}");
        Console.WriteLine($"   Device Type: {_deviceType}");
        Console.WriteLine($"   In Rotation");
        Console.WriteLine($"   Aquisition Year: {_aquisitionYear}");
        Console.WriteLine($"   Replacement Year: {_replacementYear}");
        Console.WriteLine($"   Location: {_location.Item1}, {_location.Item2}");
        Console.WriteLine($"   Owner: {_owner}");
    }
}