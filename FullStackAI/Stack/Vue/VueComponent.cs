namespace FullStackAI.Stack.Vue;

public class VueComponent
{
    public VueElement RootElement = new(new VueTag("template"));
    public VueComponentScript Script { get; set; } = new();

    public override string ToString()
    {
        return base.ToString();
    }

    public string Render()
    {
        return RootElement.Render() + Script.Render();
    }
}