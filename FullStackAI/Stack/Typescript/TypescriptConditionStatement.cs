namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypescriptConditionStatement : TypeScriptStatement
        {
            private readonly TypeScriptStatement _leftside;
            private readonly TypeScriptBooleanOperator _op;
            private readonly TypeScriptStatement _rightside;

            public TypescriptConditionStatement(TypeScriptStatement leftside, TypeScriptBooleanOperator op,
                TypeScriptStatement rightside)
            {
                _leftside = leftside;
                _op = op;
                _rightside = rightside;
            }

            public override string Render()
            {
                return $"{_leftside.Render()} {_op.Render()} {_rightside.Render()}";
            }
        }
    }
}