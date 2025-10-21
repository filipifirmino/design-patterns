using BuilderPattern.Builders;
using BuilderPattern.Model;

namespace BuilderPattern.Interface;

public interface IMessageBuilder
{
    public MessageBuilder SetBody(string body);
    public MessageBuilder SetHeader(string header);
    public MessageBuilder SetPriority(int priority);
    public MessageBuilder SetIdempotenceKey(string key);
    public Message Build();
    public void Reset();
}