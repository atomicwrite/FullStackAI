using FullStackAI.Stack.Typescript;

namespace FullStackAI.Stack.Vue;

public class VueVModel
{
    private readonly string _name;
    private readonly string _setting;
    private readonly TypescriptTypeDeclaration _type;

    public VueVModel(string setting, string name, TypescriptTypeDeclaration type)
    {
        _setting = setting;
        _name = name;
        _type = type;
    }

    public string Render()
    {
        return $"@VModel({_setting}) name {_type.Render()} ";
    }
}