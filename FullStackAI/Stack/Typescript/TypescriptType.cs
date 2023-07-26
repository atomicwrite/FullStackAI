namespace FullStackAI.Stack.Typescript;

public class TypescriptType
{
    private readonly string _name;

    public TypescriptType(string name)
    {
        _name = name;
    }

    public string Render()
    {
        if (string.IsNullOrEmpty(_name)) return "";
        return ": " + _name;
    }
}