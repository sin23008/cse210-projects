class Word
{
    // All attributes can be read but not changed outside of the class
    public string _text { get; private set; }
    public bool IsHidden { get; private set; }


    public Word(string text)
    {
        _text = text;
        IsHidden = false;
    }


    public void Hide()
    {
        IsHidden = true;
    }

    public string GetWord()
    {
        return IsHidden ? new string('_', _text.Length) : _text;
    }
}