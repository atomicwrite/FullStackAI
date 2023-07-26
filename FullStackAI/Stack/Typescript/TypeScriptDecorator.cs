namespace FullStackAI.Stack.Typescript;

public class TypeScriptDecorator
{
    private readonly string _name;
    private readonly TypeScriptStatement _settings;

    public TypeScriptDecorator(string name, TypeScriptStatement settings)
    {
        _name = name;
        _settings = settings;
    }

    public string Render()
    {
        return $"@{_name}({_settings})";
    }
}