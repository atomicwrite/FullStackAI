namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypeScriptIf : TypeScriptStatement
        {
            private readonly TypescriptConditionStatement _condition;
            private readonly TypeScriptStatement[] _false;
            private readonly TypeScriptStatement[] _true;

            public TypeScriptIf(TypescriptConditionStatement condition, TypeScriptStatement[] @true,
                TypeScriptStatement[] @false)
            {
                _condition = condition;
                _true = @true;
                _false = @false;
            }

            public override string Render()
            {
                var falseStr = _false.Length > 0
                    ? $"else {{ {string.Join(Environment.NewLine, _false.Select(a => a.Render()))} }}"
                    : "";
                var trueStr = $"{{ {string.Join(Environment.NewLine, _true.Select(a => a.Render()))} }} ";
                var conditionStr = _condition.Render();

                return $@"if({conditionStr})  {trueStr} {falseStr} ";
            }
        }
    }
}