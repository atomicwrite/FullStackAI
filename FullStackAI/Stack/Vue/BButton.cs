namespace FullStackAI.Stack.Vue;

public class BButton : VueElement
{
    public BButton(string text, params VueAttribute[] attributes) : base(new VueTag("b-button", attributes))
    {
        TextContent = text;
    }
}