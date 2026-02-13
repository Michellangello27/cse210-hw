public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        // Stub for now
        return 0;
    }

    public override bool IsComplete()
    {
        // Usa el campo (evita CS0414)
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Stub: devuelve algo válido para guardar/cargar
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}
