// See https://aka.ms/new-console-template for more information


using ObserverPattern.Models;
using ObserverPattern.Services;

var product = new Product
{
    Name = "Notebook sony",
    Price = 1000,
    Quantity = 0,
    Sku = "123456789"
};


product.Attach(new AnalyticsService());
product.Attach(new InventoryService());
product.Attach(new NotificationService());

product.Restock(100);
