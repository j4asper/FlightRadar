namespace FlightRadar.Entities.Models.V1;

public class Code
{
    public string? Iata { get; set; }
    
    public required string Icao { get; set; }
}