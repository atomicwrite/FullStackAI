namespace FullStackAI.Stack.CS;

public static class KittyHelper
{
    public static class KittyViewHelper
    {
        public class CStyleAssignment : CStyleStatement
        {
            private readonly CStyleStatement _statement;
            private readonly CStyleVariable _variable;

            public CStyleAssignment(CStyleVariable variable, CStyleStatement statement)
            {
                _variable = variable;
                _statement = statement;
            }

            public override string Render()
            {
                return $"{_variable.Render()} = {_statement.Render()}";
            }
        }
    }
}