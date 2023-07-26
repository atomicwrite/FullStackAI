using FullStackAI.Stack.CS;

namespace FullStackAI.Stack;

public class ServiceStackStackEndPointWriter : IStackWriter
{
    public CStyleClass ClassFileContents { get; init; }
    public CStyleClass RequestObjectFileContents { get; set; }
    public CStyleClass ResponseObjectFileContents { get; set; }
    public string FileFolder { get; set; }

    public bool Write()
    {
        throw new NotImplementedException();
    }
}