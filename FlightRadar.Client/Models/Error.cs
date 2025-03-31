namespace FlightRadar.Client.Models;

public class Error
{
    public required string Message { get; set; }
    public string? Details { get; set; }
}