using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [
            new Rectangle("blue", 3, 2),
            new Square("red", 5),
            new Circle("orange", 2)
        ];

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
            Console.WriteLine();
        }
    }
}