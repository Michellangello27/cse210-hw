using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _currentLevel;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _currentLevel = CalculateLevel(_score);
    }

    public void Start()
    {
        int option = -1;

        while (option != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            option = ReadIntInRange(1, 6);

            Console.WriteLine();

            if (option == 1) CreateGoal();
            else if (option == 2) ListGoalDetails();
            else if (option == 3) SaveGoals();
            else if (option == 4) LoadGoals();
            else if (option == 5) RecordEvent();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first.");
            return;
        }

        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type = ReadIntInRange(1, 3);

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadIntMin(0);

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = ReadIntMin(1);

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = ReadIntMin(0);

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        int index = ReadIntInRange(1, _goals.Count) - 1;

        Goal selectedGoal = _goals[index];

        bool wasCompleteBefore = selectedGoal.IsComplete();
        int earned = selectedGoal.RecordEvent();

        _score += earned;

        Console.WriteLine($"You earned {earned} points!");

        bool isCompleteAfter = selectedGoal.IsComplete();
        if (!wasCompleteBefore && isCompleteAfter)
        {
            Console.WriteLine("Badge unlocked: Goal completed!");
        }

        HandleLevelUp();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] values = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    values[0],
                    values[1],
                    int.Parse(values[2]),
                    bool.Parse(values[3])
                ));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    values[0],
                    values[1],
                    int.Parse(values[2])
                ));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    values[0],
                    values[1],
                    int.Parse(values[2]),
                    int.Parse(values[3]),
                    int.Parse(values[4]),
                    int.Parse(values[5])
                ));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private void HandleLevelUp()
    {
        int newLevel = CalculateLevel(_score);

        if (newLevel > _currentLevel)
        {
            _currentLevel = newLevel;
            Console.WriteLine($"🎉 Level Up! You are now Level {_currentLevel}!");
        }
    }

    private int CalculateLevel(int score)
    {
        return (score / 1000) + 1;
    }

   
    private int ReadIntInRange(int min, int max)
    {
        int value = 0;
        bool ok = false;

        while (!ok)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= min && value <= max)
            {
                ok = true;
            }
            else
            {
                Console.Write($"Enter a number between {min} and {max}: ");
            }
        }

        return value;
    }

    private int ReadIntMin(int min)
    {
        int value = 0;
        bool ok = false;

        while (!ok)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value >= min)
            {
                ok = true;
            }
            else
            {
                Console.Write($"Enter a number >= {min}: ");
            }
        }

        return value;
    }
}
