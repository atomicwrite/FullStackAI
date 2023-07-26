namespace FullStackAI.Stack;

public class ServiceStackStackViewWriter : IStackWriter
{
    public string Name { get; set; }
    public StackFile ViewFile { get; set; }
    public StackFile InlineFile { get; set; }

    public bool Write()
    {
        throw new NotImplementedException();
    }
}