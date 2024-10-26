using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public abstract class Goal
{
    protected string Name;
    protected int Points;
    protected bool IsComplete;

    public Goal(string name, int points) { Name = name; Points = points; IsComplete = false; }

    public virtual int CompleteGoal() { IsComplete = true; return Points; }
    public abstract void DisplayGoal();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }
    public override void DisplayGoal() => Console.WriteLine($"{(IsComplete ? "[X]" : "[ ]")} Simple Goal: {Name} - {Points} pts");
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
    public override int CompleteGoal() => Points; // Points each time without completion
    public override void DisplayGoal() => Console.WriteLine($"[ ] Eternal Goal: {Name} - {Points} pts each time");
}

public class ChecklistGoal : Goal
{
    private int _completedTimes, _targetCount, _bonus;

    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points) 
    { _targetCount = targetCount; _bonus = bonus; _completedTimes = 0; }

    public override int CompleteGoal()
    {
        _completedTimes++;
        if (_completedTimes >= _targetCount) { IsComplete = true; return Points + _bonus; }
        return Points;
    }

    public override void DisplayGoal() => Console.WriteLine($"{(IsComplete ? "[X]" : "[ ]")} Checklist Goal: {Name} - {Points} pts, Completed {_completedTimes}/{_targetCount}");
}

public class GoalTracker
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void AddGoal(Goal goal) => _goals.Add(goal);
    public void RecordGoal(int index) => _score += _goals[index].CompleteGoal();
    public void DisplayGoals() { foreach (var goal in _goals) goal.DisplayGoal(); Console.WriteLine($"Total Score: {_score}"); }

    public void Save(string path) => File.WriteAllText(path, JsonSerializer.Serialize(new { Goals = _goals, Score = _score }));
    public void Load(string path) { if (File.Exists(path)) { var data = JsonSerializer.Deserialize<dynamic>(File.ReadAllText(path)); _score = data.Score; _goals = data.Goals; } }
}
