namespace FullStackAI.Stack.Vue;

public class VueBTh : VueElement
{
    public VueBTh(string stringContent, params VueAttribute[] attributes) : base(
        new VueTag("b-th", attributes), stringContent)
    {
    }
}