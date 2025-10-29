using FacadePattern.Models;

namespace FacadePattern.Interfaces;

public interface IGenerateTicket
{
    public string Generate(Flight flight, decimal tax = 0);
}