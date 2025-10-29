using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;

namespace DecoratorPattern.Services;

public class NotifierDecorator : INotifier
{
    private INotifier _notifier;
    public NotifierDecorator(INotifier notifier)
    {
        _notifier = notifier;
    }

    public virtual void send(Message message)
    {
        _notifier.send(message);
    }
}