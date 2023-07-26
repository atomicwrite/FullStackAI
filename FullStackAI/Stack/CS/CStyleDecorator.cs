namespace FullStackAI.Stack.CS;

public class CStyleDecorator : CStyleStatement
{
    private readonly string _name;
    private readonly CStyleStatement[] _options;

    public CStyleDecorator(string name, CStyleStatement[] options)
    {
        _name = name;

        _options = options ?? Array.Empty<CStyleStatement>();
    }

    public override string ToString()
    {
        return Render();
    }

    public override string Render()
    {
        var parametersStr = string.Join(",", _options.Select(a => a.Render()));
        return $"[{_name}({parametersStr})]";
    }
}