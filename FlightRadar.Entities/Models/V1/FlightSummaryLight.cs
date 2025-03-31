using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightSummaryLight
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to each flight leg.
    /// </summary>
    [JsonPropertyName("fr24_id")]
    public required string Fr24Id { get; set; }

    /// <summary>
    /// Commercial flight number.
    /// </summary>
    [JsonPropertyName("flight")]
    public string? FlightNumber { get; set; }

    /// <summary>
    /// Callsign used by Air Traffic Control to denote a specific flight (as sent by aircraft transponder).
    /// </summary>
    [JsonPropertyName("callsign")]
    public string? Callsign { get; set; }

    /// <summary>
    /// ICAO code of the airline carrier as derived from flight callsign.
    /// </summary>
    [JsonPropertyName("operating_as")]
    public string? OperatingAs { get; set; }

    /// <summary>
    /// ICAO code of the carrier mapped from FR24's internal database.
    /// </summary>
    [JsonPropertyName("painted_as")]
    public string? PaintedAs { get; set; }

    /// <summary>
    /// Aircraft ICAO type code.
    /// </summary>
    [JsonPropertyName("type")]
    public string? AircraftType { get; set; }

    /// <summary>
    /// Aircraft registration as matched from Mode-S identifier.
    /// </summary>
    [JsonPropertyName("reg")]
    public string? Registration { get; set; }

    /// <summary>
    /// Origin airport ICAO code.
    /// </summary>
    [JsonPropertyName("orig_icao")]
    public string? OriginICAO { get; set; }

    /// <summary>
    /// Datetime of takeoff in UTC (YYYY-MM-DDTHH:MM:SS).
    /// </summary>
    [JsonPropertyName("datetime_takeoff")]
    public DateTime? DateTimeTakeoff { get; set; }

    /// <summary>
    /// Destination airport ICAO code.
    /// </summary>
    [JsonPropertyName("dest_icao")]
    public string? DestinationICAO { get; set; }

    /// <summary>
    /// Datetime of landing in UTC.
    /// </summary>
    [JsonPropertyName("datetime_landed")]
    public DateTime? DateTimeLanded { get; set; }

    /// <summary>
    /// 24 bit Mode-S identifier expressed in hexadecimal format.
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }

    /// <summary>
    /// Datetime when the aircraft was first detected for this flight leg (UTC).
    /// </summary>
    [JsonPropertyName("first_seen")]
    public DateTime? FirstSeen { get; set; }

    /// <summary>
    /// Datetime when the aircraft was last detected for this flight leg (UTC).
    /// </summary>
    [JsonPropertyName("last_seen")]
    public DateTime? LastSeen { get; set; }

    /// <summary>
    /// Flag indicating if the flight is live (currently tracked) or historical.
    /// </summary>
    [JsonPropertyName("flight_ended")]
    public bool? FlightEnded { get; set; }
}