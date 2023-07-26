namespace FullStackAI.Stack.Vue;

public class VueAttribute
{
    private readonly string _name;
    private readonly string _value;

    public VueAttribute(string name, string value)
    {
        _name = name;
        _value = value;
    }

    public string Render()
    {
        return $"{_name}=\"{_value}\"";
    }
}