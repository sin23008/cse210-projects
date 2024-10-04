class Costume
{
    // attributes (member variables)
    public string _headWear;
    public string _gloves;
    public string _shoes;
    public string _lowerGarment;
    public string _upperGarment;
    public string _accessory;

    // behaviors
    public void ShowWardrobe()
    {
        string result = "";
        result += $"Head: {_headWear}\n";
        result += $"Hands: {_gloves}\n";
        result += $"Feet: {_shoes}\n";
        result += $"Torso: {_upperGarment}\n";
        result += $"Legs: {_lowerGarment}\n";
        result += $"Accessory: {_accessory}\n";
        Console.WriteLine(result);
    }
}