namespace Sandbox2;

class Program
{
    static void Main(string[] args)
    {
        int i = 1;
        int j = 1;

        int inew = i++;
        int jnew = ++j;

        Console.WriteLine(i);
        Console.WriteLine(j);
    }
}
