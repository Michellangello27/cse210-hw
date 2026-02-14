using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath."
        )
    {
    }

    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            BreathBarWithCountdown(seconds: 4, grow: true);

            if (DateTime.Now >= endTime) break;

            Console.Write("Now breathe out... ");
            BreathBarWithCountdown(seconds: 6, grow: false);

            Console.WriteLine();
        }
    }

        private void BreathBarWithCountdown(int seconds, bool grow)
    {
        char block = '▓';        // ALT 178
        int maxBars = 25;
        int stepsPerSecond = 12;

        int barLeft = Console.CursorLeft;
        int barTop = Console.CursorTop;

        Console.Write(new string(' ', maxBars) + "  ");
        int countdownLeft = Console.CursorLeft;
        int countdownTop = Console.CursorTop;

        int totalSteps = Math.Max(1, seconds * stepsPerSecond);

        for (int step = 0; step <= totalSteps; step++)
        {
            double t = (double)step / totalSteps; 

            double progress = grow ? t : (1 - t);

            double eased = Math.Sin(progress * Math.PI / 2); //more natural easing 

            int bars = (int)Math.Round(eased * maxBars);
            if (bars < 0) bars = 0;
            if (bars > maxBars) bars = maxBars;

            Console.SetCursorPosition(barLeft, barTop);
            Console.Write(new string(block, bars).PadRight(maxBars, ' '));

            int remaining = seconds - (int)Math.Floor(t * seconds);
            if (remaining < 0) remaining = 0;

            Console.SetCursorPosition(countdownLeft, countdownTop);
            Console.Write($"({remaining:00})");

            Thread.Sleep(1000 / stepsPerSecond);
        }

        Console.SetCursorPosition(barLeft, barTop);
        Console.Write(new string(' ', maxBars));
        Console.SetCursorPosition(countdownLeft, countdownTop);
        Console.Write("    ");
        Console.WriteLine();
    }
}
