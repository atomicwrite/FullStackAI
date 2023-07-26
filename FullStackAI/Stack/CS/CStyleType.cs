namespace FullStackAI.Stack.CS;

public class CStyleType
{
    private readonly string? _name;

    public CStyleType(string? name)
    {
        _name = name;
    }

    public string? Render()
    {
        return string.IsNullOrEmpty(_name) ? "" : _name;
    }
}