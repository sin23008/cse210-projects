class PartTime : Employee
{
    private Employee _supervisor;
    public PartTime(string name, string email, string role, Employee supervisor) : base(name, email, role)
    {
        _supervisor = supervisor;
    }
}