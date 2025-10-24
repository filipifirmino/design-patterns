using ObserverPattern.Models;

namespace ObserverPattern.Interfaces;

public interface IObserver
{
    void Update(Product product);
}