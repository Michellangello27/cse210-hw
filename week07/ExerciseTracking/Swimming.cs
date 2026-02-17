using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (km) = laps * 50 / 1000
        return (_laps * 50.0) / 1000.0;
    }

    public override double GetSpeed()
    {
        // Velocity (km/h) = (distance / minutes) * 60
        return (GetDistance() / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        //Ritm (min/km) = minutes / distance
        return Minutes / GetDistance();
    }
}
