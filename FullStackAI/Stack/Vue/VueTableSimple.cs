namespace FullStackAI.Stack.Vue;

public class VueTableSimple : VueElement
{
    public VueTableSimple(params VueAttribute[] attributes) : base(
        new VueTag("b-table-simple", attributes))
    {
    }

    public static VueTableSimple Default => new(new VueAttribute(":hover", "true"));
}