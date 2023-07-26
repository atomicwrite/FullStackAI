using FullStackAI.Stack;

namespace FullStackAI.ServiceStack.VueSpa;

public class CreateCreateEndPointOptions
{
    public StackField[] FieldInfos { get; set; }

    public string RequestObjectNewObjectField { get; set; }
    public string TypeName { get; set; }
    public string RequestObjectType { get; set; }
    public string ResponseObjectType { get; set; }
    public string ComponentName { get; set; }
    public string HttpVerb { get; set; }

    public static CreateCreateEndPointOptions FromType(Type t)
    {
        return new CreateCreateEndPointOptions();
    }
}