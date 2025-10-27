using FactoryPattern.Interfaces;

namespace FactoryPattern.Factories;

public abstract class FactoryPayment
{
    public abstract IPayment CreatePayment();
}