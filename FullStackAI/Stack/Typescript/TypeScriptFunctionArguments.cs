namespace FullStackAI.Stack.Typescript;

 
        public class TypeScriptFunctionArguments : TypeScriptStatement
        {
            private readonly TypeScriptStatement _requestArgument;

            public TypeScriptFunctionArguments(TypeScriptStatement requestArgument)
            {
                _requestArgument = requestArgument;
            }

            public TypeScriptFunctionArguments(TypeScriptObject requestArgument)
            {
                _requestArgument = requestArgument;
            }

            public override string Render()
            {
                return _requestArgument.Render();
            }
        }
 