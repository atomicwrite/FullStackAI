namespace FullStackAI.Stack.CS;

public class CStyleClassField : CStyleStatement
{
    private readonly string _accessor;
    private readonly string _defaultValue;
    private readonly CStyleLambda _getter;
    private readonly bool _getterSetter;
    private readonly CStyleLambda _setter;
    protected readonly List<CStyleDecorator> Decorators;
    protected readonly string? Name;
    protected readonly CStyleTypeDeclaration Type;

    public CStyleClassField(string? name, CStyleTypeDeclaration type, string defaultValue = "",
        string accessor = "public", bool getterSetter = true, CStyleLambda cStyleLambdaGetter = null,
        CStyleLambda cStyleLambdaSetter = null, params CStyleDecorator[] decorators)
    {
        _getter = cStyleLambdaGetter ??= CStyleLambda.Get;
        _setter = cStyleLambdaSetter ??= CStyleLambda.Set;
        Decorators = new List<CStyleDecorator>(decorators);
        Name = name;
        Type = type;
        _accessor = accessor;
        _getterSetter = getterSetter;

        _defaultValue = defaultValue;
    }

    public override string Render()
    {
        var dValue = "";
        var hasDefaultValue = !string.IsNullOrEmpty(_defaultValue);
        if (hasDefaultValue) dValue = " = " + _defaultValue;

        var getterSteterStr = "";
        if (_getterSetter)
        {
            var renderGetter = _getter != null ? _getter.Render() : "";
            var renderSetter = _setter != null ? _setter.Render() : "";
            getterSteterStr = $"{{ {renderGetter} {renderSetter} }}";
        }

        var semi = "";
        if (hasDefaultValue || !_getterSetter) semi = ";";

        var decoratorString = string.Join(Environment.NewLine, Decorators.Select(a => a.Render()));
        return @$"
                                {decoratorString}
                                {_accessor} {Type.Render()} {Name}  {getterSteterStr} {dValue} {semi}
";
    }
}