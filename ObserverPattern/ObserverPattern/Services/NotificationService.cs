using ObserverPattern.Interfaces;
using ObserverPattern.Models;

namespace ObserverPattern.Services;

public class NotificationService : IObserver
{
    public void Update(Product product)
    {
       Console.WriteLine($"Notify all user about update quantity of product: {product.Name}, new quantity: {product.Quantity}");
    }
}