using System;
using System.Collections.Generic; //to handle data collections List<Scripture> and List<Word>
using System.IO; //The File.ReadAllLines function allows you to read the scriptures.txt file.

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary(string filePath)
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        LoadFromFile(filePath);
    }

    private void LoadFromFile(string filePath)
{
    
    if (!File.Exists(filePath)) return;

    foreach (string line in File.ReadAllLines(filePath))
    {
        if (string.IsNullOrWhiteSpace(line)) continue;

        string[] parts = line.Split('|');

        if (parts.Length < 6) 
        {
            continue; 
        }

        try 
        {
            string bookOf = parts[0];
            string book = parts[1];
            int chapter = int.Parse(parts[2]);
            int startVerse = int.Parse(parts[3]);
            int endVerse = int.Parse(parts[4]);
            string text = parts[5];

            Reference reference = new Reference(bookOf, book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(reference, text);
            _scriptures.Add(scripture);
        }
        catch (Exception)
        {
            continue;
        }
    }
}

    public Scripture GetRandomScriptureByBookOf(string bookOf)
    {
        List<Scripture> filtered = new List<Scripture>();

        foreach (Scripture scripture in _scriptures)
        {
            if (scripture.GetBookOf() == bookOf)
            {
                filtered.Add(scripture);
            }
        }

        int index = _random.Next(filtered.Count);
        return filtered[index];
    }
}
