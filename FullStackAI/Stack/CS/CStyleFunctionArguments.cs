namespace FullStackAI.Stack.CS;

public class CStyleFunctionArguments : CStyleStatement
{
    private readonly CStyleStatement _requestArgument;

    public CStyleFunctionArguments(CStyleStatement requestArgument)
    {
        _requestArgument = requestArgument;
    }

    public CStyleFunctionArguments(CStyleObject requestArgument)
    {
        _requestArgument = requestArgument;
    }

    public override string Render()
    {
        return _requestArgument.Render();
    }
}