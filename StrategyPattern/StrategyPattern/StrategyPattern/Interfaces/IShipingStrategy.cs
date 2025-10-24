using StrategyPattern.Models;

namespace StrategyPattern.Interfaces;

public interface IShippingStrategy
{
    public decimal CalculateShippingCost(Package package);
}