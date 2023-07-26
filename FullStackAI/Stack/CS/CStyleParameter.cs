namespace FullStackAI.Stack.CS;

public class CStyleParameter
{
    private readonly string _name;
    private readonly CStyleTypeDeclaration _type;

    public CStyleParameter(string name, CStyleTypeDeclaration type)
    {
        _name = name;
        _type = type;
    }

    public string Render()
    {
        return $"{_type.Render()} {_name}";
    }
}