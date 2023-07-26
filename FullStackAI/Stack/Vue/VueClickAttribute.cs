namespace FullStackAI.Stack.Vue;

public class VueClickAttribute : VueAttribute
{
    public VueClickAttribute(string value) : base("@click", value)
    {
    }
}