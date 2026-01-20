
using System;

public class Journal
{
    public List<Entry>_entries;
    public string file ="Journal.txt";

    public void AddEntry(Entry newEntry)
    {
      _entries.Add(newEntry);
    }
    public void DisplayAll()
    {

    }
    public void SavetoFile(string file)
    {

    }

    public void LoadFromFile(string file)
    {

    }
}
