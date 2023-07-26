using FullStackAI.Stack.Typescript;

namespace FullStackAI.Stack.Vue;

public class VueProp : TypeScriptClassField
{
    public VueProp(string settings, string name, TypescriptTypeDeclaration type, string defaultValue) : base(name,
        type, defaultValue, new TypeScriptDecorator("Prop", settings))
    {
    }

    internal string Render()
    {
        throw new NotImplementedException();
    }
}