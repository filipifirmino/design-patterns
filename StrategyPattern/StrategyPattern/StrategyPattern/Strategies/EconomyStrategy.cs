using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies;

public class EconomyStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(Package package)
    {
        return (package.Weight + package.Height + package.Width + package.Depth) * 1.5m ;
    }
}