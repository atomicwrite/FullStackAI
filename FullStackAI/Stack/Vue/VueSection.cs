namespace FullStackAI.Stack.Vue;

public class VueSection : VueElement
{
    public VueSection(string textContent = "", params VueAttribute[] attributes) : base(
        new VueTag("section", attributes), textContent)
    {
    }
}