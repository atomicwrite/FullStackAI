namespace FullStackAI.Stack.Vue;

public class VFor : VueAttribute
{
    private readonly string _loopOverVariable;
    private readonly string _loopVariable;
    private readonly string _loopVariableInit;

    public VFor(string loopVariable, string loopOverVariable, string loopVariableInit = "") : base("v-for",
        $"{loopVariableInit} {loopVariable}  of {loopOverVariable}")
    {
        _loopVariable = loopVariable;
        _loopOverVariable = loopOverVariable;
        _loopVariableInit = loopVariableInit;
    }
}