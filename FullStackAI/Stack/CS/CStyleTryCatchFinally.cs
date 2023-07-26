namespace FullStackAI.Stack.CS;

public class CStyleTryCatchFinally : CStyleStatement
{
    private readonly CStyleStatement[] _catch;
    private readonly string _exceptionName;
    private readonly CStyleStatement[] _finally;
    private readonly CStyleStatement[] _try;

    public CStyleTryCatchFinally(CStyleStatement[] @try, CStyleStatement[] @catch = null,
        CStyleStatement[] @finally = null, string exceptionName = "e")
    {
        _try = @try ?? Array.Empty<CStyleStatement>();
        _catch = @catch ?? Array.Empty<CStyleStatement>();
        _finally = @finally ?? Array.Empty<CStyleStatement>();
        _exceptionName = exceptionName;
    }

    public override string Render()
    {
        var tryBlock = string.Join(Environment.NewLine, _try.Select(a => a.Render()));
        var catchBlock = string.Join(Environment.NewLine, _catch.Select(a => a.Render()));
        var finallyBlock = string.Join(Environment.NewLine, _finally.Select(a => a.Render()));
        return @$"try {{
                            {tryBlock}
                            }}catch(Exception {_exceptionName}){{ 
                        {
                            catchBlock
                        }
                }}finally{{  

                        {finallyBlock}

}}


";
    }
}