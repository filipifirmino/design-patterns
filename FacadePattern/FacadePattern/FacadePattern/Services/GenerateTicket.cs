using FacadePattern.Interfaces;
using FacadePattern.Models;
using System.Text;

namespace FacadePattern.Services;

public class GenerateTicket : IGenerateTicket
{
    public string Generate(Flight flight, decimal tax = 0)
    {
        var ticketId = Guid.NewGuid();
        var generatedAt = DateTime.Now;
        var totalAmount = flight.Price + tax;
        
        var ticket = new StringBuilder();
        ticket.AppendLine("═══════════════════════════════════════");
        ticket.AppendLine("   E-TICKET / BILHETE ELETRÔNICO");
        ticket.AppendLine("═══════════════════════════════════════");
        ticket.AppendLine();
        ticket.AppendLine($"Ticket ID: {ticketId}");
        ticket.AppendLine($"Generated At: {generatedAt:yyyy-MM-dd HH:mm:ss}");
        ticket.AppendLine();
        ticket.AppendLine("Flight Information / Informações do Voo:");
        ticket.AppendLine($"  Flight Number: {flight.FlightNumber}");
        ticket.AppendLine($"  Destination: {flight.Destination}");
        ticket.AppendLine($"  Departure: {flight.Departure}");
        ticket.AppendLine($"  Arrival: {flight.Arrival}");
        ticket.AppendLine();
        ticket.AppendLine("Payment Information / Informações de Pagamento:");
        ticket.AppendLine($"  Base Price: {flight.Price:C}");
        if (tax > 0)
        {
            ticket.AppendLine($"  Tax: {tax:C}");
        }
        ticket.AppendLine($"  Total Amount: {totalAmount:C}");
        ticket.AppendLine();
        ticket.AppendLine("═══════════════════════════════════════");
        ticket.AppendLine("         Have a safe flight!");
        ticket.AppendLine("         Tenha um bom voo!");
        ticket.AppendLine("═══════════════════════════════════════");
        
        return ticket.ToString();
    }
}