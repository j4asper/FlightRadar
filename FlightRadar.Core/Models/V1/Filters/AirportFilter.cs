namespace FlightRadar.Core.Models.V1.Filters;

public class AirportFilter
{
    /// <summary>
    /// Airports specified by IATA or ICAO codes or countries specified by ISO 3166-1 alpha-2 codes.
    /// </summary>
    public required string Code { get; set; }
    
    /// <summary>
    /// both - both directions (default direction when not specified) <para/>
    /// inbound - flights to airport <para/>
    /// outbound - flight from airport <para/>
    /// </summary>
    public Direction Direction { get; set; } = Direction.Both;

    public override string ToString() => $"{Code}:{Direction.ToString().ToLower()}";
}