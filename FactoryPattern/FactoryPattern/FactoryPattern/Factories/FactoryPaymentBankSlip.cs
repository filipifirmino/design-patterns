using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Factories;

public class FactoryPaymentBankSlip : FactoryPayment
{
    private readonly ITax _tax;

    public FactoryPaymentBankSlip(ITax tax)
    {
        _tax = tax;
    }
    public override IPayment CreatePayment()
    {
        return new PaymentBankSlip(_tax);
    }
}