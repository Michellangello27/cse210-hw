using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm)
        : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        //Velocity (km/h) = (distance / minutes) * 60
        return (GetDistance() / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        //Ritm (min/km) = minutes / distance
        return Minutes / GetDistance();
    }
}
