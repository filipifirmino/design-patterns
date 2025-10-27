using System.Globalization;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class PaymentCard(ITax tax) : IPayment
{
    public void Pay(decimal value)
    {
        var tx = tax.Calculate(value);
        Console.WriteLine(
            $"Payment for Card with value R$ {
                value.ToString("F2", CultureInfo.InvariantCulture)
            } with tax of R$ {
                tx.ToString("F2", CultureInfo.InvariantCulture)
            }");
    }
}