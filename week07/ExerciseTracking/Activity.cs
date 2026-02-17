using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // for km
    public abstract double GetSpeed();    // for km/h
    public abstract double GetPace();     // for min/km

    public virtual string GetSummary()
    {
        string dateText = Date.ToString("dd MMM yyyy");

        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{dateText} {GetType().Name} ({Minutes} min): " +
               $"Distancia {distance:F2} km, Velocidad: {speed:F2} km/h, Ritmo: {pace:F2} min por km";
    }
}
