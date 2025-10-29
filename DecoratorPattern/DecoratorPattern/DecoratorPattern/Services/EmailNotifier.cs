using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;

namespace DecoratorPattern.Services;

public class EmailNotifier  : INotifier
{
    public void send(Message message)
    {
        Console.WriteLine($"Ëmail notification sent to {message.Subject} with message: {message.Body}");
    }
}