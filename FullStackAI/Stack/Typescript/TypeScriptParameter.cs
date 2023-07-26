namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypeScriptParameter
        {
            private readonly string _name;
            private readonly TypescriptTypeDeclaration _type;

            public TypeScriptParameter(string name, TypescriptTypeDeclaration type)
            {
                _name = name;
                _type = type;
            }

            public string Render()
            {
                return $"{_name} {_type.Render()}";
            }
        }
    }
}