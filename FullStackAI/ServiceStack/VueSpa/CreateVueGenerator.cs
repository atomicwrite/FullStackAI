using FullStackAI.Stack;
using FullStackAI.Stack.Typescript;
using FullStackAI.Stack.Vue;
using static FullStackAI.Stack.Typescript.KittyHelper.KittyViewHelper;

namespace FullStackAI.ServiceStack.VueSpa;

public class CreateVueGenerator
{
    private readonly string _maskTypeName;
    private readonly CreateCreateEndPointOptions _options;

    public CreateVueGenerator(CreateCreateEndPointOptions options)
    {
        _options = options;
        _maskTypeName = options.TypeName + "CreateMask";
    }


    public VueComponent Create()
    {
        VueComponent baseComponent = new();


        var maskTypeName = _options.TypeName + "CreateMask";

        CreateCreateComponentTemplate(baseComponent);
        var script = baseComponent.Script;

        CreateCreateScriptImports(script);

        var apiMixin = CreateMixin();
        var maskMixin = CreateMaskForType();

        var componentClass = CreateComponentClass(apiMixin);


        script.VueClass.Add(maskMixin);
        script.VueClass.Add(apiMixin);


        script.VueClass.Add(componentClass);

        return baseComponent;
    }

    private void CreateCreateScriptImports(VueComponentScript script)
    {
        script.Imports.Add(new VueImport("vue-property-decorator", "Component", "Vue"));
        script.Imports.Add(new VueImport("vue-property-decorator", "{Mixins}"));
        script.Imports.Add(new VueImport("@/shared", "{client}"));
        script.Imports.Add(new VueImport("@/shared/dtos", _options.RequestObjectType, _options.TypeName,
            _options.ResponseObjectType));
    }

    private void CreateCreateComponentTemplate(VueComponent baseComponent)
    {
        var root = baseComponent.RootElement;
        VueElement sectionElement = new VueSection();
        VueElement containerDiv = new VueDiv();

        root.AddChild(sectionElement);
        sectionElement.AddChild(containerDiv);

        containerDiv.AddChild(new VueH4($"Create {_options.TypeName}Mask"));

        containerDiv.AddChild(new VueBAlert("{{  DataModel.Message }}", new VueAttribute(":show", "true"),
            new VIf("DataModel.Message.length >0")));

        CreateCreateFormFields(containerDiv);
    }

    private TypeScriptClass CreateMaskForType()
    {
        //init?: Partial<ResponseError>
        //(Object as any).assign(this, init);
        var superCall = new TypescriptFunctionCall("super");
        TypeScriptStatement[] block =
        {
            superCall,
            ";",
            new TypescriptFunctionCall("(Object as any).assign", new TypeScriptFunctionArguments[]
            {
                new("this"),
                new("init")
            })
        };

        TypeScriptClassField[] fields =
        {
            new("Message", new TypescriptTypeDeclaration("string"), "\"\""),
            new("Success", new TypescriptTypeDeclaration("boolean"), "true"),
            new("Completed", new TypescriptTypeDeclaration("boolean"), "true"),
            new("Error", new TypescriptTypeDeclaration("string"), "\"\"")
        };
        TypeScriptParameter[] parameters =
        {
            new("init?", new TypescriptTypeDeclaration("Partial<" + _maskTypeName + ">"))
        };
        TypeScriptFunction[] functions =
        {
            new("constructor", TypescriptTypeDeclaration.NoReturnType, false, block: block,
                vueParameters: parameters)
        };
        TypeScriptClass maskMixin =
            new(_maskTypeName, fields: fields, functions: functions,
                extends: new TypeScriptClass(_options.TypeName));

        maskMixin.ExportNonDefault();
        return maskMixin;
    }

    public static string TypeToInput(string fieldType)
    {
        switch (fieldType)
        {
            case "String":
                return "text";
            //StringBuilder.AppendLine(GenerateVueTextInput(field));

            case "Int32":
            case "Int64":
            case "Double":
            case "Float":
                return "number";


            case "DateTime":
                return "datetime";

            default:
                return "text";
        }
    }

    public static VueElement GenerateVueInputElement(StackField fieldInfo, string vueInputType = "text",
        bool optionsDisableUpdate = false)
    {
        var attributes = fieldInfo.Attributes;
        var labelAttr = attributes.FirstOrDefault(a => a.AttributeType.Name == "LabelAttribute");
        var descAttr = attributes.FirstOrDefault(a => a.AttributeType.Name == "DescriptionAttribute");
        var label = fieldInfo.Name;
        var desc = "";
        if (descAttr is { AttributeType.NamedArguments.Count: > 0 })
            desc = descAttr.AttributeType.NamedArguments.First().ToString();

        if (labelAttr is { AttributeType.NamedArguments.Count: > 0 })
            label = labelAttr.AttributeType.NamedArguments.First().ToString();

        var bFormGroup = new BFormGroup(new VueAttribute("id", $"fieldset-{fieldInfo.Name}"),
            new VueAttribute("description", desc!),
            new VueAttribute("label", label!),
            new VueAttribute("label-for", $"input-{fieldInfo.Name}"),
            new VueAttribute("valid-feedback", "")
        );

        bFormGroup.AddChild(new BFormInput(
            new VueAttribute("id", $"fieldset-{fieldInfo.Name}"),
            new VueAttribute(":disabled", optionsDisableUpdate.ToString().ToLower()),
            new VModelAttribute($"DataModel.{fieldInfo.Name}"),
            new VueAttribute("type", vueInputType),
            new VueAttribute(":trim", "true")));


        return bFormGroup;
    }

    private void CreateCreateFormFields(VueElement containerDiv)
    {
        foreach (var field in _options.FieldInfos)
        {
            var customAttributesData = field.Attributes;
            if (customAttributesData.Any(a => a.AttributeType.Name == "AutoIncrementAttribute")) continue;
            var typeStr = TypeToInput(field.Name);
            containerDiv.AddChild(GenerateVueInputElement(field, typeStr));
        }

        containerDiv.AddChild(new BButton("Create",
            new VueClickAttribute($"Create{_options.TypeName}(DataModel)")));
    }

    private TypeScriptClass CreateComponentClass(TypeScriptClass apiMixin)
    {
        var classFields = new TypeScriptClassField[]
        {
            new("DataModel", new TypescriptTypeDeclaration(_maskTypeName),
                $"new {_maskTypeName}(new {_options.TypeName}({{}}))")
        };
        var componentProp = new VueClassProp("Component", "{ components: {}}");
        var componentClass = new TypeScriptClass(_options.ComponentName, new[] { componentProp }, null, null,
            new[] { apiMixin }, null, null, classFields);
        return componentClass;
    }

    private TypeScriptClass CreateMixin()
    {
        TypeScriptFunctionArguments[] functionArguments =
        {
            new(
                $"new {_options.RequestObjectType}  ( {{ {_options.RequestObjectNewObjectField} : DataModel }} ) ")
        };
        var apiCallStatement =
            new TypescriptFunctionCall($"client.{_options.HttpVerb.ToLower()}", functionArguments, true);

        var block = new TypeScriptStatement[]
        {
            new TypeScriptTryCatchFinally(new TypeScriptStatement[]
                {
                    new TypescriptAssignment(
                        new TypescriptVariable("const", "Response",
                            new TypescriptType(_options.ResponseObjectType)), apiCallStatement),
                    " DataModel.Success = Response.Success;",
                    new TypeScriptIf(new TypescriptConditionStatement("Response.Id", ">", "0"),
                        new TypeScriptStatement[] { " DataModel.Message = 'Created'" },
                        new TypeScriptStatement[] { " DataModel.Message = Response.Message;" })
                },
                new TypeScriptStatement[]
                {
                    " DataModel.Message = e.message;", "console.log(e)",
                    "const fieldErrors = e.GetFieldErrors()",
                    "if (fieldErrors){",
                    //
                    "}"
                },
                excType: "WebException")
        };


        var createFunction = new TypeScriptFunction("Create" + _options.TypeName,
            new TypescriptTypeDeclaration(new TypescriptType(null)),
            true, new[] { new TypeScriptParameter("DataModel", new TypescriptTypeDeclaration(_maskTypeName)) },
            block);
        var componentProp = new VueClassProp("Component", "{ components: {}}");

        var apiMixin = new TypeScriptClass(_options.TypeName + "ApiMixin", new[] { componentProp },
            new[] { createFunction },
            TypeScriptClass.Vue);
        apiMixin.ExportNonDefault();
        return apiMixin;
    }

    public VueComponent CreateInline()
    {
        VueComponent baseComponent = new();


        CreateCreateComponentTemplate(baseComponent);
        var script = baseComponent.Script;

        CreateCreateScriptImports(script);

        var apiMixin = CreateMixin();
        var maskMixin = CreateMaskForType();

        var componentClass = CreateComponentClass(apiMixin);


        script.VueClass.Add(maskMixin);
        script.VueClass.Add(apiMixin);


        script.VueClass.Add(componentClass);

        return baseComponent;
    }
}