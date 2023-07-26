namespace FullStackAI.Stack.Vue;

public class VModelAttribute : VueAttribute
{
    public VModelAttribute(string value) : base("v-model", value)
    {
    }
}