public class Reference
{
    private string _bookOf;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string bookOf, string book, int chapter, int verse)
    {
        _bookOf = bookOf;
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string bookOf, string book, int chapter, int startVerse, int endVerse)
    {
        _bookOf = bookOf;
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetBookOf()
    {
        return _bookOf;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_bookOf} - {_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_bookOf} - {_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
