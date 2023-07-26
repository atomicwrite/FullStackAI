namespace FullStackAI.Stack;

public abstract class StackCommunication : IStackCommunication
{
    protected readonly string ProjectPath;
    protected readonly StackType Type;

    protected StackCommunication(StackType type, string projectPath)
    {
        Type = type;
        ProjectPath = projectPath;
    }

    public abstract IStackWriter GetStackView();

    public abstract IStackWriter GetStackEndPoint();

    public abstract IStackWriter GetStackMessageQueue();
}