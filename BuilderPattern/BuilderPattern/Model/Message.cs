using BuilderPattern.Interface;

namespace BuilderPattern.Model;

public class Message
{
    public string Body { get; set; }
    public string Header { get; set; }
    public int Priority { get; set; }
    public string IdempotenceKey { get; set; }
}