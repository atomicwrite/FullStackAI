namespace FullStackAI.Stack.Vue;

public class VueImport
{
    private readonly string _defaultExport;
    private readonly string[] _objects;
    private readonly string _path;
    private readonly bool _decompose;

    public VueImport(string path, params string[] decomposition)
    {
        _decompose = true;
        _path = path;
        _objects = decomposition;
    }

    public VueImport(string path, string defaultExport)
    {
        _decompose = false;
        _path = path;
        _defaultExport = defaultExport;
    }

    public string Render()
    {
        if (_decompose)
        {
            var objs = string.Join(",", _objects);
            return $"import {{ {objs} }} from '{_path}'";
        }

        return $"import {_defaultExport}  from '{_path}'";
    }
}