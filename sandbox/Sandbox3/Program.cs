class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new();
        bool validScripture = false;
        Console.Clear();
        while (!validScripture) {
        scripture = scripture.getScripture();

        if (scripture._words[0]._text != "") {
            validScripture = true;
        }
        else if (scripture._words[0]._text != "") {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nScripture not found, please try again\n");
            Console.ResetColor();
        }
        }

        while (!scripture.AllWordsHidden) {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nPress Enter to continue or type '");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("quit");
            Console.ResetColor();
            Console.Write("' to exit.\n");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        } ;
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText()+"\n");
    }
}