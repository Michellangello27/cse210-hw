using System;
using System.Collections.Generic;
using System.IO;

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
        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            Reference reference;

            if (startVerse == endVerse)
            {
                reference = new Reference(book, chapter, startVerse);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse, endVerse);
            }

            Scripture scripture = new Scripture(reference, text);
            _scriptures.Add(scripture);
        }
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
