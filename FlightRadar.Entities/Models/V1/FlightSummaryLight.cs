using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightSummaryLight
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to each flight leg.
    /// </summary>
    public required string FlightRadar24Id { get; set; }

    /// <summary>
    /// Commercial flight number.
    /// </summary>
    public string? FlightNumber { get; set; }

    /// <summary>
    /// Callsign used by Air Traffic Control to denote a specific flight (as sent by aircraft transponder).
    /// </summary>
    public string? Callsign { get; set; }

    /// <summary>
    /// ICAO code of the airline carrier as derived from flight callsign.
    /// </summary>
    public string? OperatingAs { get; set; }

    /// <summary>
    /// ICAO code of the carrier mapped from FR24's internal database.
    /// </summary>
    public string? PaintedAs { get; set; }

    /// <summary>
    /// Aircraft ICAO type code.
    /// </summary>
    public string? AircraftType { get; set; }

    /// <summary>
    /// Aircraft registration as matched from Mode-S identifier.
    /// </summary>
    public string? Registration { get; set; }

    /// <summary>
    /// Departure airport.
    /// </summary>
    public Code? DepartureAirport { get; set; }

    /// <summary>
    /// Datetime of takeoff in UTC (YYYY-MM-DDTHH:MM:SS).
    /// </summary>
    public DateTime? TakeoffTime { get; set; }

    /// <summary>
    /// Destination airport.
    /// </summary>
    public Code? DestinationAirport { get; set; }

    /// <summary>
    /// Datetime of landing in UTC.
    /// </summary>
    public DateTime? LandingTime { get; set; }

    /// <summary>
    /// 24 bit Mode-S identifier expressed in hexadecimal format.
    /// </summary>
    public string? Hex { get; set; }

    /// <summary>
    /// Datetime when the aircraft was first detected for this flight leg (UTC).
    /// </summary>
    public DateTime? FirstSeen { get; set; }

    /// <summary>
    /// Datetime when the aircraft was last detected for this flight leg (UTC).
    /// </summary>
    public DateTime? LastSeen { get; set; }

    /// <summary>
    /// Flag indicating if the flight is live (currently tracked) or historical.
    /// </summary>
    public bool? IsLive { get; set; }
}