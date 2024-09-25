using System;

class Program
{
    static void Main(string[] args)
    {
        int i = 1;
        for (;i<4;i++)
        {
            Console.WriteLine(i);
        };

        Console.Write("Outside loop: ");
        Console.WriteLine(i);
    }
}