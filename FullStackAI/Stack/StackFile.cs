namespace FullStackAI.Stack;

public class StackFile
{
    public StackFile(string contents, string filePath)
    {
        Contents = contents;
        FilePath = filePath;
    }

    public string Contents { get; set; }
    public string FilePath { get; set; }

    public bool Write()
    {
        throw new NotImplementedException();
    }
}