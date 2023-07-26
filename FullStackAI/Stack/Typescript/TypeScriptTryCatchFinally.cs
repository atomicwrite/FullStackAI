namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypeScriptTryCatchFinally : TypeScriptStatement
        {
            private readonly TypeScriptStatement[] _catch;
            private readonly string _exceptionName;
            private readonly string _excType;
            private readonly TypeScriptStatement[] _finally;
            private readonly TypeScriptStatement[] _try;

            public TypeScriptTryCatchFinally(TypeScriptStatement[] @try, TypeScriptStatement[] @catch = null,
                TypeScriptStatement[] @finally = null, string exceptionName = "e", string excType = "any")
            {
                _try = @try ?? Array.Empty<TypeScriptStatement>();
                _catch = @catch ?? Array.Empty<TypeScriptStatement>();
                _finally = @finally ?? Array.Empty<TypeScriptStatement>();
                _exceptionName = exceptionName;
                _excType = excType;
            }

            public override string Render()
            {
                var tryBlock = string.Join(Environment.NewLine, _try.Select(a => a.Render()));
                var catchBlock = string.Join(Environment.NewLine, _catch.Select(a => a.Render()));
                var finallyBlock = string.Join(Environment.NewLine, _finally.Select(a => a.Render()));
                return @$"try {{
                            {tryBlock}
                            }}catch({_exceptionName} : {_excType}){{ 
                        {
                            catchBlock
                        }
                }}finally{{  
                        {
                            finallyBlock
                        }
}}


";
            }
        }
    }
}