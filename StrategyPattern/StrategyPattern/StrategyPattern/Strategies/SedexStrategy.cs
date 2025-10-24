using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies;

public class SedexStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(Package package)
    {
        return (package.Weight + package.Height + package.Width + package.Depth) * 4.5m ;
    }
}