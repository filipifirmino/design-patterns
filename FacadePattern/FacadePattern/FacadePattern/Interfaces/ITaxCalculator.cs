using FacadePattern.Models;

namespace FacadePattern.Interfaces;

public interface ITaxCalculator
{
    public decimal CalculateTax(Flight flight);
}