using System;
using System.Collections.Generic;

public class Activity
{
    private DateTime _date;
    private int _duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetSpeed()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetPace()
    {
        return 0; // To be overridden in derived classes
    }

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} - Duration: {_duration} min, " +
               $"Distance: {GetDistance()}, Speed: {GetSpeed()}, Pace: {GetPace()}";
    }
}

public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / base.Duration) * 60; // Speed in mph
    }

    public override double GetPace()
    {
        return base.Duration / _distance; // Pace in min per mile
    }
}

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * base.Duration) / 60; // Distance = speed * time
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed; // Pace in min per mile
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50 / 1000.0) * 0.62; // Distance in miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / base.Duration) * 60; // Speed in mph
    }

    public override double GetPace()
    {
        return base.Duration / GetDistance(); // Pace in min per mile
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 5), 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
