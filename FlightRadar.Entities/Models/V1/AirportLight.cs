namespace FlightRadar.Entities.Models.V1;

public class AirportLight
{
    /// <summary>
    /// Name of the airport.
    /// </summary>
    public string? Name { get; set; }
    
    public required Code Code { get; set; }
}