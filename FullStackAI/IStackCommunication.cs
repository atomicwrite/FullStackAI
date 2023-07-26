using FullStackAI.Stack;

namespace FullStackAI;

public interface IStackCommunication
{
    public IStackWriter GetStackView();
    public IStackWriter GetStackEndPoint();
    public IStackWriter GetStackMessageQueue();
}