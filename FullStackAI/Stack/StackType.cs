namespace FullStackAI.Stack;

public class StackType
{
    public StackType(Type type)
    {
        InnerType = type;
    }

    public Type InnerType { get; }
}