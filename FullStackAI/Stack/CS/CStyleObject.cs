namespace FullStackAI.Stack.CS;

public class CStyleObject : CStyleStatement
{
    private readonly CStyleObjectInitalizer[] _initalizers;
    private readonly string? _name;

    public CStyleObject(string? name, CStyleObjectInitalizer[]? initalizers)
    {
        _name = name;

        _initalizers = initalizers ?? Array.Empty<CStyleObjectInitalizer>();
    }

    public override string Render()
    {
        var inits = string.Join(Environment.NewLine + ",", _initalizers.Select(a => a.Render()));
        return $"new {_name}() {{  {inits} }}";
    }
}