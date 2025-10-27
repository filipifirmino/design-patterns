using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class FlatTax : ITax
{
    public decimal Calculate(decimal value)
    {
        return value * 0.10m;
    }
}