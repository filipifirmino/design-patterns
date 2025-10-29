using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;

namespace DecoratorPattern.Services;

public class SmsNotifier : NotifierDecorator
{
    public SmsNotifier(INotifier notifier) : base(notifier)
    {
    }
    
    public override void send(Message message)
    {
        base.send(message);
        Console.WriteLine($"SMS notification sent to subject {message.PhoneNumber} with content: {message.Body}");
    }
}