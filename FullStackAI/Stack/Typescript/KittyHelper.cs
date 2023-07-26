namespace FullStackAI.Stack.Typescript;

public class TypescriptAssignment : TypeScriptStatement
{
    private readonly TypeScriptStatement _statement;
    private readonly TypescriptVariable _variable;

    public TypescriptAssignment(TypescriptVariable variable, TypeScriptStatement statement)
    {
        _variable = variable;
        _statement = statement;
    }

    public override string Render()
    {
        return $"{_variable.Render()} = {_statement.Render()}";
    }
}