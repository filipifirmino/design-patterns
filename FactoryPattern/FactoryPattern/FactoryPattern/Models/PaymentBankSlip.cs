using System.Globalization;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class PaymentBankSlip(ITax tax) : IPayment
{
    public void Pay(decimal value)
    {
        var tx = tax.Calculate(value);
        Console.WriteLine(
            $"Payment for Bank Slip with value R$ {
                value.ToString(CultureInfo.InvariantCulture)
            } whit tax of R$ {
                tx.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}