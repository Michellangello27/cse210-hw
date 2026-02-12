using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Welcome to the Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath."
        )
    {
    }

    protected override void RunCore()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            BreathBarAnimation(4, true);   

            Console.Write("Now breathe out... ");
            BreathBarAnimation(6, false);  

            Console.WriteLine();
        }
    }

    private void BreathBarAnimation(int seconds, bool growFast)
    {
        char block = '▓';   // ALT 178
        int maxBars = 25; 
        int stepsPerSecond = 10;
        int totalSteps = seconds * stepsPerSecond;

        int left = Console.CursorLeft;
        int top = Console.CursorTop;

        for (int step = 0; step <= totalSteps; step++)
        {
            double t = (double)step / totalSteps; 

            double eased;
            if (growFast)
                eased = Math.Sqrt(t);     
            else
                eased = 1 - t;             

            int bars = (int)Math.Round(eased * maxBars);
            if (bars < 0) bars = 0;
            if (bars > maxBars) bars = maxBars;

            Console.SetCursorPosition(left, top);
            Console.Write(new string(block, bars).PadRight(maxBars, ' '));

            Thread.Sleep(1000 / stepsPerSecond);
        }

        Console.SetCursorPosition(left, top);
        Console.Write(new string(' ', maxBars));
        Console.WriteLine();
    }
}
