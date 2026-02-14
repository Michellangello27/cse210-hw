using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name ?? "";
        _description = description ?? "";
    }

    public string Name => _name;
    public string Description => _description;

    protected int DurationSeconds => _durationSeconds;

    public void Run()
    {
        Run(null);
    }

    public void Run(ActivityTracker tracker)
    {
        DisplayStartingMessage();
        RunActivity();
        DisplayEndingMessage();

        tracker?.Increment(Name);
    }

    protected abstract void RunActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine(Description);
        Console.WriteLine();

        _durationSeconds = GetDurationFromUser();

        Console.WriteLine();
        Console.Write("Get ready... ");
        ShowSpinner(3);

        Console.Clear();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.Write("Well done! ");
        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {Name}.");
        Console.Write("Returning to menu... ");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected int GetDurationFromUser()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like your session? ");

            if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0)
                return seconds;

            Console.WriteLine("Please enter a valid positive number.");
        }
    }


    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(150);
            Console.Write("\b");
            i++;
        }

        Console.Write(" \b");
    }

    protected void ShowCountDown(int seconds)
    {
        int left = Console.CursorLeft;
        int top = Console.CursorTop;

        for (int i = seconds; i >= 1; i--)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }

        Console.SetCursorPosition(left, top);
        Console.Write("  ");
        Console.WriteLine();
    }
}
