namespace FullStackAI.Stack.Vue;

public class VueBtBody : VueElement
{
    public VueBtBody(params VueAttribute[] attributes) : base(
        new VueTag("b-tbody", attributes))
    {
    }
}