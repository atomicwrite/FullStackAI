namespace FullStackAI.ServiceStack.VueSpa.Helper;

public class ServiceStackCreateEndPointOptions
{
    public string? ServiceObjectType { get; set; }


    //The type that wraps the request
    public string? RequestObjectType { get; set; }

    public string? ServiceObjectNamespace { get; set; }

    //The return message which will have a status and error message field
    public string? ResponseObjectType { get; set; }

    //the type being wrapped by a request message
    public string? TypeName { get; set; }

    public string? RequestObjectName { get; set; }

    // the field name on the request object        
    public string? RequestObjectNewObjectField { get; set; }

    // the verb of the end point
    public string? HttpVerb { get; set; }

    //the name space of the request object
    public string? RequestObjectNamespace { get; set; }

    //the name space of the resposne object
    public string? ResponseObjectNamespace { get; set; }
    public string? TypeNamespace { get; set; }


    public static ServiceStackCreateEndPointOptions FromType(Type t)
    {
        ;
        var baseType = t.Name;
        var baseNameSpace = t.Namespace;
        var responseObjectType = $"{baseType}Response";
        var serviceObjectType = $"{baseType}Service";
        var requestObjectType = $"{baseType}Request";
        var responseObjectNamespace = $"{baseNameSpace}.{baseType}Models";
        var requestObjectNamespace = $"{baseNameSpace}.{baseType}Models";
        var serviceObjectNamespace = $"{baseNameSpace}.{baseType}Service";
        var serviceType = $"{baseType}Service";
        return new ServiceStackCreateEndPointOptions
        {
            RequestObjectName = "request",
            ServiceObjectNamespace = serviceObjectNamespace,
            RequestObjectNamespace = requestObjectNamespace,
            HttpVerb = "POST",
            TypeName = baseType,
            TypeNamespace = baseNameSpace ?? "",
            RequestObjectType = requestObjectType,
            ResponseObjectNamespace = responseObjectNamespace,
            ResponseObjectType = responseObjectType,
            RequestObjectNewObjectField = baseType,
            ServiceObjectType = serviceObjectType
        };
    }
}