using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Factories;

public class FactoryPaymentCreditCard : FactoryPayment
{
    private readonly ITax _tax;

    public FactoryPaymentCreditCard(ITax tax)
    {
        _tax = tax;
    }
    public override IPayment CreatePayment()
    {
        return new PaymentCard(_tax);
    }
}