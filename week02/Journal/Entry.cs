using System;

public class Entry
{
    public string _date;
    public string _time; //time of entry
    public string _mood; //mood of the day
    public string _tag;  //tag for the entry
    public string _promptText;
    public string _entryText;
        public void Display()
    {
        Console.WriteLine($"Date: {_date} {_time}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Tag: {_tag}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("---------------------------------");
    }
}
