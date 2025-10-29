using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;

namespace DecoratorPattern.Services;

public class PushNotifier : NotifierDecorator
{
    public PushNotifier(INotifier notifier) : base(notifier)
    {
    }
    
    public override void send(Message message)
    {
       base.send(message);
       Console.WriteLine($"Push notification sent to app with content: {message.Body}");
    }
}