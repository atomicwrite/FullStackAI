namespace FullStackAI.Stack.Vue;

public class VIf : VueAttribute
{
    private readonly string _condition;

    public VIf(string condition) : base("v-if", condition)
    {
        _condition = condition;
    }
}