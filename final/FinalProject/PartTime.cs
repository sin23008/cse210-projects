class PartTime : Employee
{
    private string _supervisorName;
    public PartTime(string name, string email, string role, string supervisor) : base(name, email, role)
    {
        _supervisorName = supervisor;
    }

    public override void ViewAssets()
    {
        Console.WriteLine("Part time employees do not have assigned assets.");
        Storage.AwaitInput();
    }
    public override void AddAsset(int asset)
    {
        Console.WriteLine("Part time employees do not have assigned assets.");
        Storage.AwaitInput();
    }
    public override void Update()
    {
        Console.WriteLine("What do you want to update? (supervisor, role, name)");
        string field = Console.ReadLine();
    }

    public override void ViewInfo()
    {
        base.ViewInfo();
        Console.WriteLine($"Supervisor: {_supervisorName}");
    }
}