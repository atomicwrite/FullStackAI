namespace FullStackAI.Stack.Typescript;

public class TypeScriptObjectInitalizer : TypeScriptStatement
{
    private readonly string _name;
    private readonly string _value;

    public TypeScriptObjectInitalizer(string name, string value)
    {
        _name = name;
        _value = value;
    }

    public override string Render()
    {
        return $"{_name} : {_value}";
    }
}