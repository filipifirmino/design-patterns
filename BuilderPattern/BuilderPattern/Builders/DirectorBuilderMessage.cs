using BuilderPattern.Interface;
using BuilderPattern.Model;

namespace BuilderPattern.Builders;

public class DirectorBuilderMessage
{
    private readonly IMessageBuilder _builder;

    public DirectorBuilderMessage(IMessageBuilder builder)
    {
        _builder = builder;
    }

    public void MessageConstruct(string body, int priority, string idempotenceKey, string header)
    {
        _builder.SetBody(body);
        _builder.SetPriority(priority);
        _builder.SetIdempotenceKey(idempotenceKey);
        _builder.SerHeader(header);
    }
    
    public Message Build() => _builder.Build();
    
}