using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private NonRepeatingStringPicker _promptPicker;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by listing as many items as you can in a certain area."
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _promptPicker = new NonRepeatingStringPicker(_prompts);
    }

    protected override void RunActivity()
    {
        string prompt = _promptPicker.Next();

        Console.WriteLine("List responses to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
        int count = 0;

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items.");
    }
}
