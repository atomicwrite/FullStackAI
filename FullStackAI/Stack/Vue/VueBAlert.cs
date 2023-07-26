namespace FullStackAI.Stack.Vue;

public class VueBAlert : VueElement
{
    public VueBAlert(string textContent = "", params VueAttribute[] attributes) : base(
        new VueTag("b-alert", attributes), textContent)
    {
    }
}