
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.80),  // 4.8 km
            new Cycling(new DateTime(2022, 11, 3), 45, 20.0),  // 20 km/h
            new Swimming(new DateTime(2022, 11, 3), 25, 40)    // 40 laps
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

// by: Angel Cornejo