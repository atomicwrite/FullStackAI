using FullStackAI.Stack.Typescript;

namespace FullStackAI.Stack.Vue;

public class VueWatcher
{
    private readonly KittyHelper.KittyViewHelper.TypeScriptFunction _function;
    private readonly TypeScriptStatement _setting;

    public VueWatcher(TypeScriptStatement setting,
        KittyHelper.KittyViewHelper.TypeScriptFunction function)
    {
        _setting = setting;
        _function = function;
    }

    internal string Render()
    {
        return $"@Watch({_setting.Render()}) {_function.Render()}";
    }
}