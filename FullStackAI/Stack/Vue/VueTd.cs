namespace FullStackAI.Stack.Vue;

public class VueTd : VueElement
{
    public VueTd(params VueAttribute[] attributes) : base(
        new VueTag("b-td", attributes))
    {
    }

    public VueTd(string textContent, params VueAttribute[] attributes) : base(
        new VueTag("b-td", attributes), textContent)
    {
    }

    public static VueTd Default => new();
}