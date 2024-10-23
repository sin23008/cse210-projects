class Scripture
{
    public ScriptureReference _reference {get; private set;}
    public List<Word> _words {get; private set;}
    public bool AllWordsHidden => _words.All(w => w.IsHidden || !IsStr(w._text));

    public Scripture()
    {
        _reference = new ScriptureReference("", 0, 0);
        _words = "".Split(" ").Select(word => new Word(word)).ToList();
    }

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public Scripture getScripture()
    {
        Console.WriteLine("\nWhat verse would you like to memorize? ");
        string userInput = Console.ReadLine();

        int lastSpaceIndex = userInput.LastIndexOf(" ");
        int colonIndex = userInput.IndexOf(":");

        if (lastSpaceIndex > 0 && colonIndex > lastSpaceIndex)
        {
            string book = userInput.Substring(0, lastSpaceIndex);
            int chapter = int.Parse(userInput.Substring(lastSpaceIndex + 1, colonIndex - lastSpaceIndex - 1));
            string verseString = userInput.Substring(colonIndex + 1);

            string[] verses = verseString.Split("-");
            int verseStart = int.Parse(verses[0]);
            int verseEnd = verses.Length > 1 ? int.Parse(verses[1]) : verseStart;

            _reference = verseStart == verseEnd
            ? new ScriptureReference(book, chapter, verseStart)
            : new ScriptureReference(book, chapter, verseStart, verseEnd);

            string filePath = "scriptures/lds-scriptures.csv";
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CSV file not found.");
                Console.ResetColor();
                return new Scripture(_reference, "");
            }

            string[] lines = File.ReadAllLines(filePath);

            string words = "";

            for (int i = 0; i <= verseEnd - verseStart; i++)
            {
                bool isFirstLine = true;
                foreach (string line in lines)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    string userBook = _reference._book.ToLower();
                    int userChapter = _reference._chapter;
                    int userVerse = _reference._verseStart + i;
                    string[] fields = line.Split('~');
                    string csvBook = fields[0].Trim().ToLower();
                    int csvChapter = int.Parse(fields[1].Trim());
                    int csvVerse = int.Parse(fields[2].Trim());
                    string text = fields[3].Trim().Substring(1, fields[3].Trim().Length - 2);

                    if (userBook == csvBook && userChapter == csvChapter && userVerse == csvVerse)
                    {
                        words = words + $"{userVerse} {text}\n";
                    }
                }
            }
            return new Scripture(_reference, words);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid input format");
            Console.ResetColor();
            return new Scripture(new ScriptureReference("", 0, 0), "");
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetReferenceString()}\n";
        displayText += string.Join(" ", _words.Select(w => w.GetWord()));
        return displayText;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden && IsStr(w._text)).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    private bool IsStr(string str)
    {
        return !string.IsNullOrWhiteSpace(str) && !int.TryParse(str, out _) && !str.All(char.IsPunctuation);
    }
    
}