namespace FullStackAI.Stack.Vue;

public class VueH2 : VueElement
{
    public VueH2(string textContent = "", params VueAttribute[] attributes) : base(new VueTag("h2", attributes),
        textContent)
    {
    }
}