using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class VariableTax : ITax
{
    public decimal Calculate(decimal value)
    {
        if (value <= 100)
            return value * 0.05m;
        if (value <= 1000)
            return value * 0.08m;
        return value * 0.12m;
    }
}