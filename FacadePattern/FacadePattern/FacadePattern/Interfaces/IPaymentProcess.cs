using FacadePattern.Models;

namespace FacadePattern.Interfaces;

public interface IPaymentProcess
{
    public bool Pay(Flight flight, decimal tax);
}