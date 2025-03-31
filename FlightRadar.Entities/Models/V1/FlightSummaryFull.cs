using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightSummaryFull
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
    /// Origin airport IATA code.
    /// </summary>
    [JsonPropertyName("orig_iata")]
    public string? OriginIATA { get; set; }

    /// <summary>
    /// Datetime of takeoff in UTC.
    /// </summary>
    [JsonPropertyName("datetime_takeoff")]
    public DateTime? DateTimeTakeoff { get; set; }

    /// <summary>
    /// Identifier of the runway used for takeoff.
    /// </summary>
    [JsonPropertyName("runway_takeoff")]
    public string? RunwayTakeoff { get; set; }

    /// <summary>
    /// Destination airport ICAO code.
    /// </summary>
    [JsonPropertyName("dest_icao")]
    public string? DestinationICAO { get; set; }

    /// <summary>
    /// Destination airport IATA code.
    /// </summary>
    [JsonPropertyName("dest_iata")]
    public string? DestinationIATA { get; set; }

    /// <summary>
    /// ICAO code for the actual destination airport (different when diverted).
    /// </summary>
    [JsonPropertyName("dest_icao_actual")]
    public string? DestinationICAOActual { get; set; }

    /// <summary>
    /// IATA code for the actual destination airport (different when diverted).
    /// </summary>
    [JsonPropertyName("dest_iata_actual")]
    public string? DestinationIATAActual { get; set; }

    /// <summary>
    /// Datetime of landing in UTC.
    /// </summary>
    [JsonPropertyName("datetime_landed")]
    public DateTime? DateTimeLanded { get; set; }

    /// <summary>
    /// Identifier of the runway used for landing.
    /// </summary>
    [JsonPropertyName("runway_landed")]
    public string? RunwayLanded { get; set; }

    /// <summary>
    /// Duration of the flight from takeoff to landing in seconds.
    /// </summary>
    [JsonPropertyName("flight_time")]
    public int? FlightTime { get; set; }

    /// <summary>
    /// Actual ground distance the aircraft traveled (in km).
    /// </summary>
    [JsonPropertyName("actual_distance")]
    public float? ActualDistance { get; set; }

    /// <summary>
    /// Great-circle distance between the first and last position (in km).
    /// </summary>
    [JsonPropertyName("circle_distance")]
    public float? CircleDistance { get; set; }

    /// <summary>
    /// 24-bit Mode-S identifier in hexadecimal format.
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