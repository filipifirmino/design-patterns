using FacadePattern.Models;

namespace FacadePattern.Interfaces;

public interface ICheckFlight
{
    public bool CheckAvailability(Flight flight);
}