namespace FullStackAI.Stack.Typescript;

public static partial class KittyHelper
{
    public static partial class KittyViewHelper
    {
        public class TypeScriptFunction : TypeScriptStatement
        {
            private readonly bool _async;
            private readonly TypeScriptStatement[] _block;
            private readonly TypeScriptDecorator[] _decorators;
            private readonly string _name;
            private readonly TypescriptTypeDeclaration _returnType;
            private readonly TypeScriptParameter[] _vueParameters;

            public TypeScriptFunction(string name, TypescriptTypeDeclaration returnType, bool async,
                TypeScriptParameter[] vueParameters = null, TypeScriptStatement[] block = null,
                TypeScriptDecorator[] decorators = null)
            {
                _name = name;
                _returnType = returnType;
                _async = async;
                _vueParameters = vueParameters ?? Array.Empty<TypeScriptParameter>();
                _decorators = decorators ?? Array.Empty<TypeScriptDecorator>();
                _block = block ?? Array.Empty<TypeScriptStatement>();
            }

            public override string Render()
            {
                var decoratorString = string.Join(Environment.NewLine, _decorators.Select(a => a.Render()));
                var parameterSTring = string.Join(",", _vueParameters.Select(a => a.Render()));
                var blocks = string.Join(Environment.NewLine, _block.Select(a => a.Render()));
                var asy = _async ? "async" : "";
                return $@"
                          {decoratorString}
                        {asy} {_name} ({parameterSTring}) {{
                                    
                                    {blocks}
                                        
                                    }}
";
            }
        }
    }
}