using System;

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
            ShowCountdown(5);

            Console.Write("Now breathe out... ");
            ShowCountdown(5);

            Console.WriteLine(); //space between cycles
        }
    }
}
