using FullStackAI.Stack.Vue;

namespace FullStackAI.Stack.Typescript;

public class TypeScriptClass : TypeScriptStatement
{
    public static TypeScriptClass Vue = new("Vue");
    private readonly VueClassProp[] _classProps;
    private readonly TypeScriptClass _extends;
    private readonly TypeScriptClassField[] _fields;
    private readonly KittyHelper.KittyViewHelper.TypeScriptFunction[] _functions;
    private readonly TypeScriptClass[] _mixins;
    private readonly string _name;
    private readonly VueProp[] _props;
    private readonly VueVModel[] _vmodels;
    private readonly VueWatcher[] _watchers;
    private string _exportString;

    public TypeScriptClass(string name, VueClassProp[] classProps = null,
        KittyHelper.KittyViewHelper.TypeScriptFunction[] functions = null, TypeScriptClass extends = null,
        TypeScriptClass[] mixins = null, VueVModel[] vmodels = null, VueProp[] props = null,
        TypeScriptClassField[] fields = null, VueWatcher[] watchers = null)
    {
        _name = name;
        _exportString = "export default ";
        _classProps = classProps ?? Array.Empty<VueClassProp>();
        _extends = extends;
        _mixins = mixins ?? Array.Empty<TypeScriptClass>();
        _vmodels = vmodels ?? Array.Empty<VueVModel>();
        _props = props ?? Array.Empty<VueProp>();
        _fields = fields ?? Array.Empty<TypeScriptClassField>();
        _watchers = watchers ?? Array.Empty<VueWatcher>();
        _functions = functions ?? Array.Empty<KittyHelper.KittyViewHelper.TypeScriptFunction>();
    }

    public string ExternalRequirePath { get; set; }
    public string ExportName { get; set; }

    public override string Render()
    {
        var extendsStr = "";

        var classPropStr = string.Join(Environment.NewLine, _classProps.Select(a => a.Render()));
        var vvmodelsStr = string.Join(Environment.NewLine, _vmodels.Select(a => a.Render()));
        var propsStr = string.Join(Environment.NewLine, _props.Select(a => a.Render()));
        var fieldsStr = string.Join(Environment.NewLine, _fields.Select(a => a.Render()));
        var watchersStr = string.Join(Environment.NewLine, _watchers.Select(a => a.Render()));
        var functionsStr = string.Join(Environment.NewLine, _functions.Select(a => a.Render()));


        if (_mixins.Length != 0)
            extendsStr = "extends Mixins(" + string.Join(",", _mixins.Select(a => a._name)) + ")";
        else if (_extends != null) extendsStr = "extends " + _extends._name;

        return @$"
                                 {classPropStr}
                                 {_exportString} class {_name} {extendsStr} {{
                                    {propsStr}
                                    {vvmodelsStr}
                                    {fieldsStr}
                                    {watchersStr}
                                    {functionsStr}
                    }}

";
    }

    public void ExportNonDefault()
    {
        _exportString = "export";
    }
}