namespace FullStackAI.Stack.Vue;

public class VueTag
{
    private readonly string _tagName;
    private readonly List<VueAttribute> _attributes;

    public VueTag(string tagName, params VueAttribute[] vueAttributes)
    {
        _tagName = tagName;

        _attributes = new List<VueAttribute>(vueAttributes);
    }

    public string OpenTag()
    {
        var attributesStr = string.Join(" ", _attributes.Select(a => a.Render()));
        return $"<{_tagName} {attributesStr}>";
    }

    public string CloseTag()
    {
        return $"</{_tagName}>";
    }

    public void AddAttribute(VueAttribute a)
    {
        _attributes.Add(a);
    }
}