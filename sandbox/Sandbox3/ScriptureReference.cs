using System.Globalization;
class ScriptureReference
{
    public string _book {get; private set; }
    public int _chapter {get; private set; }
    public int _verseStart {get; private set; }
    public int? _verseEnd {get; private set; }


    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }


    public string GetReferenceString()
    {   
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        if (_verseEnd.HasValue)
            return $"{textInfo.ToTitleCase(_book)} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{textInfo.ToTitleCase(_book)} {_chapter}:{_verseStart}";
            
    }
}