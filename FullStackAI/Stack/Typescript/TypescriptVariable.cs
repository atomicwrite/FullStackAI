namespace FullStackAI.Stack.Typescript;

public class TypescriptVariable : TypeScriptStatement
{
    private readonly string _init;
    private readonly string _name;
    private readonly TypescriptType _type;

    public TypescriptVariable(string init, string name, TypescriptType type)
    {
        _init = init;
        _name = name;
        _type = type;
    }

    public override string Render()
    {
        var typeStr = _type?.Render();

        return $"{_init} {_name} {typeStr}";
    }
}