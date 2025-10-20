
using BuilderPattern.Model;

var order = new Order.Builder()
    .WithCustomerName("John Doe")
    .WithOrderItems(new List<Itens>
    {
        new Itens { Name = "Item1", Quantity = 2, Price = 10.0m },
        new Itens { Name = "Item2", Quantity = 1, Price = 20.0m }
    })
    .Build();
    
    Console.WriteLine(order.ToString());