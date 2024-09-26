namespace Sandbox3;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new();
        int d1 = randomGenerator.Next(1,7);
        int d2 = randomGenerator.Next(1,7);
        int d3 = randomGenerator.Next(1,7);

        if (d2 > d3)
        {
            (d2, d3) = (d3, d2);
        }
        if (d1 > d3)
        {
            (d1, d3) = (d3, d1);
        }
        if (d1 > d2)
        {
            (d1, d2) = (d2, d1);
        }

        Console.WriteLine($"They are {d1}, {d2}, {d3}");
    }
}
