using System.Reflection.Metadata;

class FullTime : Employee
{
    private (string, string) _location;
    private int _extension;
    private List<Asset> _assets;
    public FullTime(string name, string email, string role) : base(name, email, role)
    {
    }
}