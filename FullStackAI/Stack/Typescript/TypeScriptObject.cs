namespace FullStackAI.Stack.Typescript;

public class TypeScriptObject : TypeScriptStatement
{
    private readonly TypeScriptObjectInitalizer[] _initalizers;
    private readonly string? _name;
    private readonly TypeScriptFunctionArguments[]? _parameters;

    public TypeScriptObject(TypeScriptObjectInitalizer[] initalizers = null)
    {
        _initalizers = initalizers ?? Array.Empty<TypeScriptObjectInitalizer>();
    }

    public TypeScriptObject(string name, TypeScriptFunctionArguments[]? parameters = null)
    {
        _name = name;
        _initalizers = Array.Empty<TypeScriptObjectInitalizer>();
        _parameters = parameters;
    }

    public override string Render()
    {
        if (_name == null)
            return "{" + string.Join("," + Environment.NewLine, _initalizers.Select(a => a.Render())) + "}";

        var param = "";
        if (_parameters != null) param = string.Join(",", _parameters.Select(a => a.Render()));

        return $"new {_name}({param})";
    }
}