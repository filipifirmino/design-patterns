using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Services;

public class CheckFlight : ICheckFlight
{
    private readonly HashSet<int> _availableFlights = new() { 123, 456, 789, 101, 202 };
    
    private readonly HashSet<int> _soldOutFlights = new() { 303, 404 };
    
    public bool CheckAvailability(Flight flight)
    {

        if (_availableFlights.Contains(flight.FlightNumber))
        {
            Console.WriteLine($"✓ Flight {flight.FlightNumber} to {flight.Destination} is available");
            return true;
        }
        
        if (_soldOutFlights.Contains(flight.FlightNumber))
        {
            Console.WriteLine($"✗ Flight {flight.FlightNumber} to {flight.Destination} is sold out");
            return false;
        }

        Console.WriteLine($"✗ Flight {flight.FlightNumber} not found in our system");
        return false;
    }
}