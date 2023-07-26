namespace FullStackAI.Stack.Typescript;

 
        public class TypescriptFunctionCall : TypeScriptStatement
        {
            private readonly bool _await;
            private readonly TypeScriptFunctionArguments[] _calls;
            private readonly string _functionname;

            public TypescriptFunctionCall(string functionname, TypeScriptFunctionArguments[]? calls = null,
                bool await = false)
            {
                _functionname = functionname;
                _calls = calls ?? Array.Empty<TypeScriptFunctionArguments>();
                _await = await;
            }

            public override string Render()
            {
                var argumentsToFunction = string.Join("", _calls.Select(a => a.Render()));
                var awaitz = _await ? "await" : "";
                return $"{awaitz} {_functionname}({argumentsToFunction})";
            }
        }
 