namespace FullStackAI.Stack.CS;

public class CStyleVariable : CsPrintable
{
    private readonly string _init;
    private readonly string _name;
    private readonly CStyleType _type;

    public CStyleVariable(string init, string name, CStyleType type)
    {
        _init = init;
        _name = name;
        _type = type;
    }

    public override string Render()
    {
        var typeStr = _type.Render();

        return $"{_init} {_name} {typeStr}";
    }
}