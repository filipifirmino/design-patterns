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
        _builder.SetBody(body)
            .SetPriority(priority)
            .SetIdempotenceKey(idempotenceKey)
            .SetHeader(header);
    }
    
    public Message Build() {
        var result = _builder.Build();
        _builder.Reset();
        return result;
    }
    
}