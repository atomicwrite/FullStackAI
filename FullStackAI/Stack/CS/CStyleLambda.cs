namespace FullStackAI.Stack.CS;

public class CStyleLambda : CStyleStatement
{
    private readonly CStyleStatement[]? _body;
    private readonly CStyleParameter[] _parameters;

    public CStyleLambda(CStyleParameter[] parameters, CStyleStatement[]? body = null)
    {
        _parameters = parameters;
        _body = body;
    }

    public static CStyleLambda Get => new(new[] { new CStyleParameter("get", new CStyleTypeDeclaration("")) });

    public static CStyleLambda Set => new(new[] { new CStyleParameter("set", new CStyleTypeDeclaration("")) });

    public override string Render()
    {
        var parametersStr = string.Join(",", _parameters.Select(a => a.Render()));
        if (_body == null)
            return _parameters.Length switch
            {
                0 => "()=>{}",
                1 => $"{parametersStr};",
                _ => $"({parametersStr})"
            };

        var bodyStr = string.Join(Environment.NewLine, _body.Select(a => a.Render()));
        return _parameters.Length switch
        {
            0 => $"()=>{{{bodyStr}}}",
            1 => $"{parametersStr} => {{{bodyStr}}}",
            _ => $"({parametersStr})=>{{{bodyStr}}}"
        };
    }
}