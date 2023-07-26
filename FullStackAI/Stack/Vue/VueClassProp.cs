using FullStackAI.Stack.Typescript;

namespace FullStackAI.Stack.Vue;

public class VueClassProp : TypeScriptStatement
{
    private readonly string _name;
    private readonly TypeScriptStatement _options;

    public VueClassProp(string name, TypeScriptStatement options)
    {
        _name = name;

        _options = options;
    }

    public override string ToString()
    {
        return Render();
    }

    public override string Render()
    {
        return $"@{_name}({_options.Render()})   ";
    }
}