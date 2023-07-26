namespace FullStackAI.Stack.Vue;

public class BCardTitle : VueElement
{
    public BCardTitle(string content, params VueAttribute[] attributes) : base(new VueTag("b-card-title", attributes),
        content)
    {
    }
}