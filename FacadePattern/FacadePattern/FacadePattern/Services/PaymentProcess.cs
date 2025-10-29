using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Services;

public class PaymentProcess : IPaymentProcess
{
   private const decimal MinimumAmount = 0.01m;
    
   private const decimal MaximumAmount = 100000m;
    
    public bool Pay(Flight flight, decimal tax)
    {
        var totalAmount = flight.Price + tax;
        
        if (totalAmount < MinimumAmount)
        {
            Console.WriteLine($"✗ Payment failed: Amount too low ({totalAmount:C})");
            return false;
        }
        
        if (totalAmount > MaximumAmount)
        {
            Console.WriteLine($"✗ Payment failed: Amount exceeds maximum limit ({MaximumAmount:C})");
            return false;
        }
        
        if (flight.Price < 0 || tax < 0)
        {
            Console.WriteLine($"✗ Payment failed: Invalid amount (price or tax cannot be negative)");
            return false;
        }
        
        // Simula processamento de pagamento (em produção, aqui faria chamada para gateway de pagamento)
        Console.WriteLine($"Processing payment...");
        Console.WriteLine($"  Base Price: {flight.Price:C}");
        Console.WriteLine($"  Tax: {tax:C}");
        Console.WriteLine($"  Total Amount: {totalAmount:C}");
        Console.WriteLine($"✓ Payment processed successfully!");
        
        return true;
    }
}