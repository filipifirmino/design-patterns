using ObserverPattern.Interfaces;

namespace ObserverPattern.Models;

public class Product : ISubject
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Sku { get; set; }
    

    private readonly List<IObserver> _clients = [];
    
    public void Restock(int quantity)
    {
        Quantity += quantity;
        Notify(this);
    }

    public void Attach(IObserver client)
    {
       _clients.Add(client);
    }

    public void Detach(IObserver client)
    {
        _clients.Remove(client);
    }

    public void Notify(Product product)
    {
        foreach (var c in _clients)
        {
            c.Update(product);
        }
    }
}