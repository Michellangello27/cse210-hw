using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureActivity : Activity
{
    private NonRepeatingScripturePicker _scriptures;
    private string _filePath;

    public ScriptureActivity(string filePath)
        : base(
            "Scripture Activity",
            "This activity shows a scripture and asks what ideas or principles come to your mind."
        )
    {
        _filePath = filePath;
        List<Scripture> scriptures = LoadFromFile(_filePath);
        _scriptures = new NonRepeatingScripturePicker(scriptures);
    }

    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        if (_scriptures == null || _scriptures.RemainingInCycle() == 0)
        {
            Console.WriteLine("No scriptures found. Please check scriptures.txt.");
            Console.WriteLine("Press Enter to return...");
            Console.ReadLine();
            return;
        }

        while (DateTime.Now < endTime)
        {
            if (_scriptures.RemainingInCycle() == 0)
            {
                Console.WriteLine("You already used all scriptures available for this session.");
                break;
            }

            Scripture current = _scriptures.Next();
            if (current == null) break;

            Console.WriteLine($"--- {current.Reference} ---");
            Console.WriteLine(current.Text);
            Console.WriteLine();
            Console.Write("What ideas or principles come to your mind? ");
            Console.ReadLine();

            Console.WriteLine();
            Console.Write("Thinking... ");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private List<Scripture> LoadFromFile(string filePath)
    {
        List<Scripture> list = new List<Scripture>();

        if (!File.Exists(filePath))
            return list;

        foreach (string line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split('|');
            if (parts.Length < 6)
                continue;

            string source = parts[0].Trim();
            string book = parts[1].Trim();
            string chapter = parts[2].Trim();
            string startVerse = parts[3].Trim();
            string endVerse = parts[4].Trim();
            string text = string.Join("|", parts, 5, parts.Length - 5).Trim();

            list.Add(new Scripture(source, book, chapter, startVerse, endVerse, text));
        }

        return list;
    }
}
