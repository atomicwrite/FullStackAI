using FullStackAI.Stack.CS;

namespace FullStackAI.ServiceStack.VueSpa.Helper;

public class ServiceStackCreateEndPoint
{
    private readonly ServiceStackCreateEndPointOptions _options;
    //  private readonly GenerateEndPointAuthHelper<T> helper;

    public ServiceStackCreateEndPoint(ServiceStackCreateEndPointOptions options)
    {
        _options = options;
        //  helper = new GenerateEndPointAuthHelper<T>(_options);
    }


    public virtual CStyleClass Create()
    {
        var createFunctionParameters = new[]
        {
            new CStyleParameter("request",
                new CStyleTypeDeclaration(_options.RequestObjectType))
        };
        var createFunction = GenerateCreateFunction(createFunctionParameters);
        var usings = GenerateUsings();
        var parentClass =
            new CStyleClass("ServiceStack.Service", _options.ServiceObjectNamespace, Array.Empty<string>());
        var createClass =
            new CStyleClass(GenerateFunctionName(), _options.ServiceObjectNamespace, usings,
                extends: parentClass,
                functions: new[]
                {
                    createFunction
                });


        return createClass;
    }

    protected virtual string GenerateFunctionName()
    {
        return "Create" + _options.TypeName;
    }

    private CStyleObject GenerateReturnObject()
    {
        return new CStyleObject(_options.ResponseObjectType,
            new[]
            {
                new CStyleObjectInitalizer("Id", "id")
            });
    }

    protected virtual CStyleStatement GenerateDatabaseMethod()
    {
        return
            $" var id= Db.Insert( {_options.RequestObjectName}.{_options.RequestObjectNewObjectField},true);";
    }

    protected virtual CStyleFunction GenerateCreateFunction(CStyleParameter[] createFunctionParameters)
    {
        var createFunction =
            new CStyleFunction(_options.HttpVerb,
                new CStyleTypeDeclaration(_options.ResponseObjectType), true,
                createFunctionParameters,
                new CStyleStatement[]
                {
                    new CStyleTryCatchFinally(new[]
                    {
                        // new CStyleStatement(helper.GenerateUserLookUp()),
                        // new CStyleStatement(helper.GenerateAssignToUser()),
                        GenerateDatabaseMethod(),
                        "return ", GenerateReturnObject(),
                        ";"
                    }, new CStyleStatement[]
                    {
                        "return ", GenerateReturnObjectOnError(),
                        ";"
                    })
                }
            );
        return createFunction;
    }

    protected virtual CStyleObject GenerateReturnObjectOnError()
    {
        return new CStyleObject(_options.ResponseObjectType,
            new CStyleObjectInitalizer[]
            {
                new("Success", "false"),
                new("Message", "e.Message")
            });
    }

    protected virtual string[] GenerateUsings()
    {
        string[] usings =
        {
            _options.RequestObjectNamespace ?? "",
            "Microsoft.AspNetCore.Hosting",
            "ServiceStack",
            "ServiceStack.Auth",
            "ServiceStack.Configuration",
            "ServiceStack.Logging",
            "System.Linq",
            "ServiceStack.OrmLite",
            "ServiceStack.FluentValidation",
            "System",
            "System.Threading.Tasks"
        };
        return usings;
    }

    public virtual CStyleClass CreateRequestClass()
    {
        var usings = new[]
        {
            "System",
            "ServiceStack",
            _options.TypeNamespace ?? ""
        };
        var extends = new
            CStyleClass(
                $"IReturn<{_options.ResponseObjectType}>", _options.RequestObjectNamespace);

        var requestObjectFields = new[]
        {
            new CStyleClassField(_options.RequestObjectNewObjectField,
                new CStyleTypeDeclaration(_options.TypeName))
        };

        return new CStyleClass(_options.RequestObjectType,
            _options.RequestObjectNamespace,
            usings,
            extends: extends,
            fields: requestObjectFields);
    }

    public virtual CStyleClass CreateResponseType()
    {
        var usings = new[]
        {
            "System"
        };
        var responseObjectFields = new[]
        {
            new CStyleClassField("Id",
                new CStyleTypeDeclaration("long")),
            new CStyleClassField("Message",
                new CStyleTypeDeclaration("string")),
            new CStyleClassField("Success",
                new CStyleTypeDeclaration("bool"), "true"),
            new CStyleClassField("ResponseStatus",
                new CStyleTypeDeclaration("ResponseStatus"))
        };
        return new CStyleClass(_options.ResponseObjectType, _options.ResponseObjectNamespace, usings, fields:
            responseObjectFields);
    }
}