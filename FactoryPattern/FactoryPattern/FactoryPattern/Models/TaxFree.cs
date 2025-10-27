using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class TaxFree : ITax
{
    public decimal Calculate(decimal value)
    {
        return 0;
    }
}