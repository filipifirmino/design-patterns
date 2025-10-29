namespace FacadePattern.Models;

public class Flight(
    int flightNumber,
    string destination,
    string departure,
    string arrival,
    decimal price)
{
    public int FlightNumber { get; set; } = flightNumber;
    public string Destination { get; set; } = destination;
    public string Departure { get; set; } = departure;
    public string Arrival { get; set; } = arrival;
    public decimal Price { get; set; } = price;
}