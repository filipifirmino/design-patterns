using FacadePattern.Facade;
using FacadePattern.Interfaces;
using FacadePattern.Models;
using FacadePattern.Services;

// Configuração dos serviços (em produção, usar Dependency Injection)
var services = CreateServices();
var ticketFacade = new TicketFacade(
    services.GenerateTicket,
    services.CheckFlight,
    services.TaxCalculator,
    services.PaymentProcess
);

// Exemplo 1: Compra de bilhete bem-sucedida
Console.WriteLine("=== Exemplo 1: Compra de Bilhete ===");
Console.WriteLine();

try
{
    var flight = new Flight(
        flightNumber: 123,
        destination: "London",
        departure: "12:00",
        arrival: "13:00",
        price: 100m
    );

    var purchaseSuccessful = ticketFacade.BuyTicket(flight);
    
    if (purchaseSuccessful)
    {
        Console.WriteLine();
        Console.WriteLine(ticketFacade.PrintTicket(flight));
    }
    else
    {
        Console.WriteLine("✗ Falha no processamento do pagamento.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Erro: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine(new string('=', 60));
Console.WriteLine();

// Exemplo 2: Tentativa de compra de voo indisponível
Console.WriteLine("=== Exemplo 2: Voo Indisponível ===");
Console.WriteLine();

try
{
    var unavailableFlight = new Flight(
        flightNumber: 404,
        destination: "Paris",
        departure: "14:00",
        arrival: "16:00",
        price: 200m
    );

    ticketFacade.BuyTicket(unavailableFlight);
}
catch (Exception ex)
{
    Console.WriteLine($"✗ {ex.Message}");
}

static (IGenerateTicket GenerateTicket, ICheckFlight CheckFlight, 
    ITaxCalculator TaxCalculator, IPaymentProcess PaymentProcess) CreateServices()
{
    return (
        new GenerateTicket(),
        new CheckFlight(),
        new TaxCalculator(),
        new PaymentProcess()
    );
}