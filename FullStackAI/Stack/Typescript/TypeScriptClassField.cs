namespace FullStackAI.Stack.Typescript;

public class TypeScriptClassField
{
    private readonly string _defaultValue;
    protected readonly List<TypeScriptDecorator> Decorators;

    protected readonly string Name;
    protected readonly TypescriptTypeDeclaration Type;

    public TypeScriptClassField(string name, TypescriptTypeDeclaration type, string defaultValue = "",
        params TypeScriptDecorator[] decorators)
    {
        Decorators = new List<TypeScriptDecorator>(decorators);
        Name = name;
        Type = type;
        _defaultValue = defaultValue;
    }

    public string Render()
    {
        var dValue = "";
        if (!string.IsNullOrEmpty(_defaultValue)) dValue = " = " + _defaultValue;
        var decoratorString = string.Join(Environment.NewLine, Decorators.Select(a => a.Render()));
        return @$"
                                {decoratorString}
                                {Name} {Type.Render()}  {dValue}
";
    }
}