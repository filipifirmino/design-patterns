using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.Services;

public class ShippingService
{
    private IShippingStrategy _strategy;

    public ShippingService(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal Calculate(Package package)
    {
        var value = _strategy.CalculateShippingCost(package);
        return value;
    }

    public void SetStrategy(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }
}