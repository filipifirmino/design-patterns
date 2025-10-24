using ObserverPattern.Interfaces;
using ObserverPattern.Models;

namespace ObserverPattern.Services;

public class AnalyticsService : IObserver
{
    public void Update(Product product)
    {
        Console.WriteLine($"Saving the data on analytics service for product: {product.Name}");
    }
}