namespace FullStackAI.Stack.CS;

public class CStyleTypeDeclaration
{
    public static CStyleTypeDeclaration NoReturnType = new(new CStyleType(null));
    private readonly CStyleType _type;

    public CStyleTypeDeclaration(string? tpe)
    {
        _type = new CStyleType(tpe);
    }

    public CStyleTypeDeclaration(CStyleType type)
    {
        _type = type;
    }

    public string? Render()
    {
        return _type.Render();
    }
}