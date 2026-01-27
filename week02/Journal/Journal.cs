
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;// for use of StringBuilder in function ParseCsvLine. StringBuilder

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
        if (!file.EndsWith(".csv")) file += ".csv";

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Time,Mood,Tag,Prompt,EntryText"); //Excel headers

            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{EscapeCsv(entry._date)},{EscapeCsv(entry._time)},{EscapeCsv(entry._mood)},{EscapeCsv(entry._tag)},{EscapeCsv(entry._promptText)},{EscapeCsv(entry._entryText)}");
            }
        }
        Console.WriteLine($"Journal saved successfully as {file}.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string header = reader.ReadLine();//jump header line

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = ParseCsvLine(line);

                if (parts.Length >= 6)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _time = parts[1],
                        _mood = parts[2],
                        _tag = parts[3],
                        _promptText = parts[4],
                        _entryText = parts[5]
                    };
                    _entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    private string EscapeCsv(string text) //For handling quotation marks
    {
        if (string.IsNullOrEmpty(text)) return "";
        return $"\"{text.Replace("\"", "\"\"")}\"";
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        StringBuilder currentPart = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    currentPart.Append('\"'); // handle double quotes escaped ""
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes; // changes the state of whether we are inside quotes
                }
            }
            else if (line[i] == ',' && !inQuotes)
            {
                parts.Add(currentPart.ToString());
                currentPart.Clear();
            }
            else
            {
                currentPart.Append(line[i]);
            }
        }
        parts.Add(currentPart.ToString());
        return parts.ToArray();
    }
}