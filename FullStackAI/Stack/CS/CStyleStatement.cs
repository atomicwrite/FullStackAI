namespace FullStackAI.Stack.CS;

public class CStyleStatement : CsPrintable
{
    private readonly string _text;

    public CStyleStatement()
    {
    }

    public CStyleStatement(string text)
    {
        _text = text;
    }

    public static implicit operator CStyleStatement(string a)
    {
        return new CStyleStatement(a);
    }

    public override string Render()
    {
        return _text;
    }
}