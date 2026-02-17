using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        Creativity / Exceeding Requirements (for the rubric):
        - Added a simple Level system: every 1000 points increases the player's Level.
        - Added a Badge message when a goal becomes completed (SimpleGoal or ChecklistGoal).
        These are small "gamification" features beyond the core requirements and are shown
        in the console during normal program use.
        */

        Console.WriteLine("This is the EternalQuest Project.");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
