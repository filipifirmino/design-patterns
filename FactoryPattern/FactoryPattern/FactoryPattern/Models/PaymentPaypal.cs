using System.Globalization;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class PaymentPaypal:IPayment
{
    private readonly ITax _tax;
    public PaymentPaypal(ITax tax)
    {
        _tax = tax;
    }
    public void Pay(decimal value)
    {
        var tax = _tax.Calculate(value);
        Console.WriteLine($"Payment for Paypal with value: R${
            value.ToString(CultureInfo.InvariantCulture)} with tax of R$ {
                tax.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}