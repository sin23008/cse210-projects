using System.Diagnostics.Contracts;

class Card : Ticket
{
    string _newAssetType;
    Asset _oldAsset;
    Asset _newAsset;
    
    public Card(int id, string title, string requestor, string newAssetType, Asset oldAsset) : base(id, title, requestor) 
    {
        _newAssetType = newAssetType;
        _oldAsset = oldAsset;
    }

    public void AssignReplacementAsset(Asset newAsset)
    {
        _newAsset = newAsset;
    }
}