namespace FlightRadar.Entities.Models.V1;

public class Airline
{
    /// <summary>
    /// Name of the airline.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Airline code.
    /// </summary>
    public required Code Code { get; set; }
}