using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Facade;

public class TicketFacade(
    IGenerateTicket generateTicket,
    ICheckFlight checkFlight,
    ITaxCalculator taxCalculator,
    IPaymentProcess paymentProcess)
    : ITicketFacade
{
    private decimal _lastCalculatedTax = 0;

    public bool BuyTicket(Flight flight)
    {
        var availableFlight = checkFlight.CheckAvailability(flight);
        if (!availableFlight)
        {
            throw new Exception("Flight is not available");
        }
        
        _lastCalculatedTax = taxCalculator.CalculateTax(flight);
        return paymentProcess.Pay(flight, _lastCalculatedTax);
    }

    public string PrintTicket(Flight flight)
    {
       return generateTicket.Generate(flight, _lastCalculatedTax);
    }
}