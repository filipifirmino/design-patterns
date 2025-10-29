using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Services;

public class TaxCalculator : ITaxCalculator
{

    private readonly Dictionary<string, decimal> _destinationTaxRates = new()
    {
        { "London", 0.20m },      // 20% para voos internacionais
        { "Paris", 0.18m },
        { "New York", 0.25m },
        { "Tokyo", 0.15m },
        { "Rio de Janeiro", 0.12m }
    };
    
    private const decimal DefaultTaxRate = 0.15m; // Taxa padrão de 15%
    
    public decimal CalculateTax(Flight flight)
    {
        var taxRate = _destinationTaxRates.TryGetValue(
            flight.Destination, 
            out var rate) ? rate : DefaultTaxRate;
        
        var taxAmount = flight.Price * taxRate;
        
        Console.WriteLine($"Tax calculated: {taxAmount:C} ({taxRate:P0} of {flight.Price:C}) for destination {flight.Destination}");
        
        return taxAmount;
    }
}