namespace FullStackAI.Stack.Vue;

public class VueH1 : VueElement
{
    public VueH1(string textContent = "", params VueAttribute[] attributes) : base(new VueTag("h1", attributes),
        textContent)
    {
    }
}