namespace FullStackAI.Stack.Vue;

public class VueTable : VueElement
{
    public VueTable(string textContent = "", params VueAttribute[] attributes) : base(
        new VueTag("b-table", attributes), textContent)
    {
    }
}