namespace FullStackAI.Stack.Vue;

public class VueDiv : VueElement
{
    public VueDiv(string textContent = "", params VueAttribute[] attributes) : base(new VueTag("div", attributes),
        textContent)
    {
    }
}