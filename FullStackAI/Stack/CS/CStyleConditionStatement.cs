namespace FullStackAI.Stack.CS;

public class CStyleConditionStatement : CStyleStatement
{
    private readonly CStyleStatement _leftside;
    private readonly CStyleBooleanOperator _op;
    private readonly CStyleStatement _rightside;

    public CStyleConditionStatement(CStyleStatement leftside, CStyleBooleanOperator op, CStyleStatement rightside)
    {
        _leftside = leftside;
        _op = op;
        _rightside = rightside;
    }

    public override string Render()
    {
        return $"{_leftside.Render()} {_op.Render()} {_rightside.Render()}";
    }
}