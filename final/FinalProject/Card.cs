class Card : Ticket
{
    string _newAssetType;
    int _oldAsset;
    int _newAsset;
    
    public Card(int id, string requestor, string newAssetType, int oldAsset) : base(id, "", requestor) 
    {
        _newAssetType = newAssetType;
        _oldAsset = oldAsset;
    }

    public void AssignReplacementAsset(int newAsset)
    {
        _newAsset = newAsset;
        _newAssetType = Storage.GetAssetById(_newAsset).GetDeviceType();
    }

    public void Display()
    {
        Console.WriteLine($"Ticket ID: {_ticketId}");
        Console.WriteLine($"New asset type: {_newAssetType}");
        Console.WriteLine($"Old asset: {_oldAsset}");
        Console.WriteLine($"New asset: {_newAsset}");
    }
}