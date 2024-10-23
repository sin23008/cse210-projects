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
        else if (scripture._words[0]._text == "") {
            Console.WriteLine("\n\x1B[1;31m-= Scripture not found, please try again =-\x1B[0m");
        }
        }

        while (!scripture._allWordsHidden) {
            Console.Clear();
            scripture.DisplayText();
            Console.Write("\nPress Enter to continue or type '");
            Console.Write("\x1B[1;3;36mquit\x1B[0m");
            Console.Write("' to exit.\n");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        } ;
        Console.Clear();
        scripture.DisplayText();
        Console.WriteLine();
    }
}