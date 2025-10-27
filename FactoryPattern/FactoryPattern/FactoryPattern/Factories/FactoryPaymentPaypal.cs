using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Factories;

public class FactoryPaymentPaypal : FactoryPayment
{
    private readonly ITax _tax;

    public FactoryPaymentPaypal(ITax tax)
    {
        _tax = tax;
    }
    public override IPayment CreatePayment()
    {
        return new PaymentPaypal(_tax);
    }
}