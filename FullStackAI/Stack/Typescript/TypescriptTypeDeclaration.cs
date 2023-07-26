namespace FullStackAI.Stack.Typescript;

public class TypescriptTypeDeclaration
{
    public static TypescriptTypeDeclaration NoReturnType = new(new TypescriptType(null));
    private readonly TypescriptType _type;

    public TypescriptTypeDeclaration(string tpe)
    {
        _type = new TypescriptType(tpe);
    }

    public TypescriptTypeDeclaration(TypescriptType type)
    {
        _type = type;
    }

    public string Render()
    {
        return _type.Render();
    }
}