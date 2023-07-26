namespace FullStackAI.Stack.CS;

public class CStyleFunction : CStyleStatement
{
    private readonly string _accessor;
    private readonly bool _async;
    private readonly CStyleStatement[] _block;
    private readonly CStyleDecorator[] _decorators;
    private readonly string? _name;
    private readonly CStyleTypeDeclaration _returnType;
    private readonly CStyleParameter[] _vueParameters;


    public CStyleFunction(string? name, CStyleTypeDeclaration returnType, bool async,
        CStyleParameter[] cStyleParameters = null, CStyleStatement[] block = null, CStyleDecorator[] decorators = null,
        string accessor = "public")
    {
        _name = name;
        _returnType = returnType;
        _async = async;
        _accessor = accessor;
        _vueParameters = cStyleParameters ?? Array.Empty<CStyleParameter>();
        _decorators = decorators ?? Array.Empty<CStyleDecorator>();
        _block = block ?? Array.Empty<CStyleStatement>();
    }

    public override string Render()
    {
        var decoratorString = string.Join(Environment.NewLine, _decorators.Select(a => a.Render()));
        var parameterSTring = string.Join(Environment.NewLine, _vueParameters.Select(a => a.Render()));
        var blocks = string.Join(Environment.NewLine, _block.Select(a => a.Render()));
        var retType = _returnType.Render();
        var asy = _async ? "async" : "";
        if (_async) retType = $"Task<{retType}> ";
        return $@"
                          {decoratorString}
                      {_accessor}  {asy} {retType} {_name} ({parameterSTring}) {{
                                    
                                    {blocks}
                                        
                                    }}
";
    }
}