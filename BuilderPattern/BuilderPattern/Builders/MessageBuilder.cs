using BuilderPattern.Interface;
using BuilderPattern.Model;

namespace BuilderPattern.Builders;

public class MessageBuilder : IMessageBuilder
{
    private Message _message = new ();

    public MessageBuilder SetBody(string body)
    {
        _message.Body = body;
        return this;
    }

    public MessageBuilder SetHeader(string header)
    {
       _message.Header = header;
       return this;
    }

    public MessageBuilder SetPriority(int priority)
    {
        _message.Priority = priority;
        return this;
    }

    public MessageBuilder SetIdempotenceKey(string key)
    {
        _message.IdempotenceKey = key;
        return this;
    }

    public Message Build() => _message;
    public void Reset()
    {
        _message = new Message();
    }
}