namespace FullStackAI.Stack.CS;

public class CStyleObjectInitalizer : CStyleStatement
{
    private readonly string _name;
    private readonly string _value;

    public CStyleObjectInitalizer(string name, string value)
    {
        _name = name;
        _value = value;
    }

    public override string Render()
    {
        return $"{_name} = {_value}";
    }
}