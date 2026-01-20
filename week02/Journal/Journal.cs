using System;


public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry
            {
                _date       = parts[0],
                _promptText = parts[1],
                _entryText  = parts[2]
            };

            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}
