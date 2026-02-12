public class Scripture
{
    public Scripture(string source, string book, string chapter, string startVerse, string endVerse, string text)
    {
        Source = source;
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
        Text = text;
    }

    public string Source { get; }
    public string Book { get; }
    public string Chapter { get; }
    public string StartVerse { get; }
    public string EndVerse { get; }
    public string Text { get; }

    public string Reference
    {
        get
        {
            if (StartVerse == EndVerse)
                return $"{Source} - {Book} {Chapter}:{StartVerse}";
            return $"{Source} - {Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
