namespace FlightRadar.Entities.Models.V1;

public class FlightPositionFull : FlightPositionLight
{
    /// <summary>
    /// Commercial flight number.
    /// </summary>
    public string? FlightNumber { get; set; }

    /// <summary>
    /// Aircraft ICAO type code.
    /// </summary>
    public string? AircraftType { get; set; }

    /// <summary>
    /// Aircraft registration as matched from Mode-S identifier.
    /// </summary>
    public string? Registration { get; set; }

    /// <summary>
    /// ICAO code of the carrier mapped from FR24's internal database.
    /// </summary>
    public string? PaintedAs { get; set; }

    /// <summary>
    /// ICAO code of the airline carrier as derived from flight callsign.
    /// </summary>
    public string? OperatingAs { get; set; }

    /// <summary>
    /// Destination airport
    /// </summary>
    public Code? DestinationAirport { get; set; }

    /// <summary>
    /// Departure airport
    /// </summary>
    public Code? DepartureAirport { get; set; }

    /// <summary>
    /// Estimated time of arrival.
    /// </summary>
    public DateTime? EstimatedTimeOfArrival { get; set; }
}