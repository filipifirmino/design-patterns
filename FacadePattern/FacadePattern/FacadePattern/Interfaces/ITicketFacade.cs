using FacadePattern.Models;

namespace FacadePattern.Interfaces;

public interface ITicketFacade
{
    public bool BuyTicket(Flight flight);
    public string PrintTicket(Flight flight);
}