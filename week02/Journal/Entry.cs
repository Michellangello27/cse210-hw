using System;

public class Entry
{
    public string _date;
    public string _time;
    public string _mood;
    public string _tag;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"---------------------------------");
        Console.WriteLine($"Date: {_date} | Time: {_time}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Tag: {_tag}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
    }
}