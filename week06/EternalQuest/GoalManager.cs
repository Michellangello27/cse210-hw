using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // Stub
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoalNames()
    {
        // Stub for now
    }

    public void ListGoalDetails()
    {
        // Stub for now
    }

    public void CreateGoal()
    {
        // Stub for now
    }

    public void RecordEvent()
    {
        // Stub for now
    }

    public void SaveGoals()
    {
        // Stub for now
    }

    public void LoadGoals()
    {
        // Stub for now
    }
}
