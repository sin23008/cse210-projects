class FullTime : Employee
{
    private (string, string) _location;
    private int _extension;
    private List<int> _assets = new List<int>();

    public FullTime(string name, string email, string role) : base(name, email, role)
    {
    }

    public FullTime()
    {
        _name = "";
        _email = "";
        _role = "";
        _location = ("", "");
    }

    public override void ViewAssets()
    {
        foreach (int asset in _assets)
        {
            Storage.GetAssetById(asset).Display();
        }
        Storage.AwaitInput();
    }

    public override void AddAsset(int asset)
    {
        _assets.Add(asset);
    }

    public override void Update()
    {
        Console.WriteLine("What do you want to update? (location, extension, role, name, status)");
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
            case "extension":
                Console.WriteLine("What is the new extension?");
                int newExtension = int.Parse(Console.ReadLine());
                _history.Add($"Extension changed from {_extension} to {newExtension}");
                _extension = newExtension;
                break;
            case "role":
                Console.WriteLine("What is the new role?");
                string newRole = Console.ReadLine();
                _history.Add($"Role changed from {_role} to {newRole}");
                _role = newRole;
                break;
            case "name":
                Console.WriteLine("What is the new name?");
                string newName = Console.ReadLine();
                _history.Add($"Name changed from {_name} to {newName}");
                _name = newName;
                break;
            case "status":
                if (_isCurrentEmployee)
                {
                    Console.WriteLine("Do you want to terminate this employee? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        _isCurrentEmployee = false;
                        _history.Add("Terminated");
                    }
                }
                break;
            default:
                Console.WriteLine("Invalid field.");
                break;
        }
    }
}