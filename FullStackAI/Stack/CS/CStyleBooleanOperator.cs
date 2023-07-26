namespace FullStackAI.Stack.CS;

public class CStyleBooleanOperator
{
    private readonly string _op;

    public CStyleBooleanOperator(string op)
    {
        _op = op;
    }

    public static implicit operator CStyleBooleanOperator(string a)
    {
        return new CStyleBooleanOperator(a);
    }

    public string Render()
    {
        return _op;
    }
}