// See https://aka.ms/new-console-template for more information

using FactoryPattern.Factories;
using FactoryPattern.Interfaces;
using FactoryPattern.Models;


var freeTax = new TaxFree();
var paymentPaypal = new Client(new FactoryPaymentPaypal(freeTax));
paymentPaypal.Pay(1000m);

var variableTax = new VariableTax();
var paymentBankSlip = new Client(new FactoryPaymentBankSlip(variableTax));
paymentBankSlip.Pay(2200.0m);

var flatTax = new FlatTax();
var paymentCreditCard = new Client(new FactoryPaymentCreditCard(flatTax));
paymentCreditCard.Pay(500.0m);


internal class Client(FactoryPayment factoryPayment)
{
    private readonly IPayment _payment = factoryPayment.CreatePayment();

    public void Pay(decimal value = 100)
    {
        _payment.Pay(value);
    }
}


