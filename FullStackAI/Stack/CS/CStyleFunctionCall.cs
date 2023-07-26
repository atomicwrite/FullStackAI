namespace FullStackAI.Stack.CS;

public class CStyleFunctionCall : CStyleStatement
{
    private readonly bool _await;
    private readonly CStyleFunctionArguments[] _calls;
    private readonly string _functionname;

    public CStyleFunctionCall(string functionname, CStyleFunctionArguments[] calls = null, bool await = false)
    {
        _functionname = functionname;
        _calls = calls ?? Array.Empty<CStyleFunctionArguments>();
        _await = await;
    }

    public override string Render()
    {
        var argumentsToFunction = string.Join(" ", _calls.Select(a => a.Render()));
        var awaitz = _await ? "await" : "";
        return $"{awaitz} {_functionname}({argumentsToFunction})";
    }
}