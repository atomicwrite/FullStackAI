using FullStackAI.ServiceStack.VueSpa.Helper;
using FullStackAI.Stack;

namespace FullStackAI.ServiceStack.VueSpa;

public class ServiceStackVueSpaCreate : StackCommunication
{
    private readonly string _vueProjectPath;


    public ServiceStackVueSpaCreate(StackType type, string projectPath, string vueProjectPath) : base(type, projectPath)
    {
        _vueProjectPath = vueProjectPath;
    }

    public override IStackWriter GetStackView()
    {
        var gen = new CreateVueGenerator(CreateCreateEndPointOptions.FromType(Type.InnerType));
        var component = gen.Create();
        var inlineComponent = gen.CreateInline();
        var name = Type.InnerType.Name;
        return new ServiceStackStackViewWriter
        {
            ViewFile = new StackFile(component.Render(),
                $"{_vueProjectPath}{Path.DirectorySeparatorChar}{name}{Path.DirectorySeparatorChar}{name}.vue"),
            InlineFile = new StackFile(inlineComponent.Render(),
                $"{_vueProjectPath}{Path.DirectorySeparatorChar}{name}{Path.DirectorySeparatorChar}{name}.vue"),
            Name = name
        };
    }

    public override IStackWriter GetStackEndPoint()
    {
        var createEndPoint = new ServiceStackCreateEndPoint(ServiceStackCreateEndPointOptions.FromType(Type.InnerType));

        return new ServiceStackStackEndPointWriter
        {
            ClassFileContents = createEndPoint.Create(),
            RequestObjectFileContents = createEndPoint.CreateRequestClass(),
            ResponseObjectFileContents = createEndPoint.CreateResponseType(),
            FileFolder = ProjectPath
        };
    }

    public override IStackWriter GetStackMessageQueue()
    {
        throw new NotImplementedException();
    }
}