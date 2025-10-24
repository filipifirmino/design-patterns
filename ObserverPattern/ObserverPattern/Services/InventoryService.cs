using ObserverPattern.Interfaces;
using ObserverPattern.Models;

namespace ObserverPattern.Services;

public class InventoryService : IObserver
{
    public void Update(Product product)
    {
        Console.WriteLine($"Product {product.Name} was added to inventory service for quantity: {product.Quantity}");
    }
}