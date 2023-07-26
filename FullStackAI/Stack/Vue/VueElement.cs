namespace FullStackAI.Stack.Vue;

public class VueElement
{
    private readonly List<VueElement> _children;
    private readonly VueTag _tag;
    protected string TextContent;

    public VueElement(VueTag tag, string textContent = "", VueElement[] children = null)
    {
        _children = children is not null ? new List<VueElement>(children) : new List<VueElement>();
        _tag = tag;
        TextContent = textContent ?? "";
    }


    public void AddChild(VueElement vueElement)
    {
        _children.Add(vueElement);
    }

    public string Render()
    {
        var content = TextContent + string.Join(Environment.NewLine, _children.Select(a => a.Render()));
        return _tag.OpenTag() + content + _tag.CloseTag();
    }
}