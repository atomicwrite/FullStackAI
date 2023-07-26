namespace FullStackAI.Stack.CS;

public class CStyleIf : CStyleStatement
{
    private readonly CStyleConditionStatement _condition;
    private readonly CStyleStatement[] _false;
    private readonly CStyleStatement[] _true;

    public CStyleIf(CStyleConditionStatement condition, CStyleStatement[] @true, CStyleStatement[] @false)
    {
        _condition = condition;
        _true = @true;
        _false = @false;
    }

    public override string Render()
    {
        var falseStr = _false.Length > 0
            ? $"else {{ {string.Join(Environment.NewLine, _false.Select(a => a.Render()))} }}"
            : "";
        var trueStr = $"{{ {string.Join(Environment.NewLine, _true.Select(a => a.Render()))} }} ";
        var conditionStr = _condition.Render();

        return $@"if({conditionStr})  {trueStr} {falseStr} ";
    }
}