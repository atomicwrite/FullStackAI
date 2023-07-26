namespace FullStackAI.Stack.Typescript;

public class TypeScriptStatement : TypeScriptPrintable
{
    private readonly string _text;

    public TypeScriptStatement()
    {
    }

    public TypeScriptStatement(string text)
    {
        _text = text;
    }

    public static implicit operator TypeScriptStatement(string a)
    {
        return new TypeScriptStatement(a);
    }

    public override string Render()
    {
        return _text;
    }
}