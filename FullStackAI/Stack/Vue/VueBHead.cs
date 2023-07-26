namespace FullStackAI.Stack.Vue;

public class VueBHead : VueElement
{
    public VueBHead(params VueAttribute[] attributes) : base(
        new VueTag("b-thead", attributes))
    {
    }

    public static VueBHead Default => new(new VueAttribute(":head-variant", "dark"));
}