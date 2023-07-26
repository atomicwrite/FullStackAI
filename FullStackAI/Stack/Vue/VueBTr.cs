namespace FullStackAI.Stack.Vue;

public class VueBTr : VueElement
{
    public VueBTr(params VueAttribute[] attributes) : base(
        new VueTag("b-tr", attributes))
    {
    }
}