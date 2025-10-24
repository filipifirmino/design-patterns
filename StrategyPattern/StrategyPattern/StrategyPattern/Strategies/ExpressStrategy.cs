using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies;

public class ExpressStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(Package package)
    {
        return (package.Weight + package.Height + package.Width + package.Depth) * 2.5m ;
    }
}