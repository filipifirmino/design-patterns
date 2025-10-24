using ObserverPattern.Models;

namespace ObserverPattern.Interfaces;

public interface ISubject
{
    void Attach(IObserver client);
    void Detach(IObserver client);
    void Notify(Product product);
}