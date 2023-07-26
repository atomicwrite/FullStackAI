namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypeScriptBooleanOperator
        {
            private readonly string _op;

            public TypeScriptBooleanOperator(string op)
            {
                _op = op;
            }

            public static implicit operator TypeScriptBooleanOperator(string a)
            {
                return new TypeScriptBooleanOperator(a);
            }

            public string Render()
            {
                return _op;
            }
        }
    }
}