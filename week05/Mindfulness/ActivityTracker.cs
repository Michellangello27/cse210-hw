using System;
using System.Collections.Generic;
using System.IO;

public class ActivityTracker
{
    private string _filePath;
    private List<string> _names;
    private List<int> _counts;

    public ActivityTracker(string filePath)
    {
        _filePath = filePath;
        _names = new List<string>();
        _counts = new List<int>();
        Load();
    }

    public void Increment(string activityName)
    {
        if (activityName == null)
            return;

        activityName = activityName.Trim();
        if (activityName == "")
            return;

        int index = IndexOfName(activityName);

        if (index == -1)
        {
            _names.Add(activityName);
            _counts.Add(1);
        }
        else
        {
            _counts[index] = _counts[index] + 1;
        }

        Save();
    }

    public void DisplayCounts()
    {
        Console.WriteLine("Activity Counts:");

        if (_names.Count == 0)
        {
            Console.WriteLine("No activity recorded yet.");
            return;
        }

        for (int i = 0; i < _names.Count; i++)
        {
            Console.WriteLine(_names[i] + ": " + _counts[i]);
        }
    }

    private int IndexOfName(string name)
    {
        for (int i = 0; i < _names.Count; i++)
        {
            if (string.Equals(_names[i], name, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }

    private void Load()
    {
        if (!File.Exists(_filePath))
            return;

        string[] lines = File.ReadAllLines(_filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line == null) continue;

            line = line.Trim();
            if (line == "") continue;

            string[] parts = line.Split('|');
            if (parts.Length != 2) continue;

            string name = parts[0].Trim();
            int count;

            if (int.TryParse(parts[1], out count))
            {
                if (name != "")
                {
                    _names.Add(name);
                    _counts.Add(count);
                }
            }
        }
    }

    private void Save()
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false))
        {
            for (int i = 0; i < _names.Count; i++)
            {
                writer.WriteLine(_names[i] + "|" + _counts[i]);
            }
        }
    }
}
