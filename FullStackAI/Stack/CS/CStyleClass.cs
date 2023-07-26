namespace FullStackAI.Stack.CS;

public class CStyleClass : CStyleStatement
{
    private readonly CStyleDecorator[] _classDecorators;

    private readonly string _classModifiers;
    private readonly CStyleClass? _extends;

    private readonly CStyleClassField[] _fields;

    private readonly CStyleFunction[] _functions;
    private readonly string? _name;

    private readonly string? _nameSpace;

    private readonly string[]? _usings;


    public CStyleClass(string? name, string? nameSpace, string[]? usings = null, string classModifiers = "public",
        CStyleDecorator[]? classProps = null, CStyleFunction[]? functions = null, CStyleClass? extends = null,
        CStyleClassField[]? fields = null)
    {
        _name = name;
        _nameSpace = nameSpace;
        _usings = usings ?? Array.Empty<string>();
        _classModifiers = classModifiers;
        _classDecorators = classProps ?? Array.Empty<CStyleDecorator>();
        _extends = extends;

        _fields = fields ?? Array.Empty<CStyleClassField>();

        _functions = functions ?? Array.Empty<CStyleFunction>();
    }

    public override string Render()
    {
        var classPropStr = string.Join(Environment.NewLine, _classDecorators.Select(a => a.Render()));

        var usingsStr = string.Join(Environment.NewLine, _usings.Select(a => $"using {a};"));
        var fieldsStr = string.Join(Environment.NewLine, _fields.Select(a => a.Render()));

        var functionsStr = string.Join(Environment.NewLine, _functions.Select(a => a.Render()));


        var extendsStr = "";
        if (_extends != null) extendsStr = ": " + _extends._name;

        return @$"{usingsStr}

                    namespace {_nameSpace} {{

                                 {classPropStr}
                                 {_classModifiers} class {_name} {extendsStr} {{
                                    {fieldsStr}
                                    {functionsStr}
                    }}
}}
";
    }
}