using DecoratorPattern.Models;

namespace DecoratorPattern.Interfaces;

public interface INotifier
{
    void send (Message message); 
}