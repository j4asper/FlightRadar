using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightPositionFull : FlightPositionLight
{
    /// <summary>
    /// Commercial flight number.
    /// </summary>
    [JsonPropertyName("flight")]
    public string? FlightNumber { get; set; }

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
    /// ICAO code of the carrier mapped from FR24's internal database.
    /// </summary>
    [JsonPropertyName("painted_as")]
    public string? PaintedAs { get; set; }

    /// <summary>
    /// ICAO code of the airline carrier as derived from flight callsign.
    /// </summary>
    [JsonPropertyName("operating_as")]
    public string? OperatingAs { get; set; }

    /// <summary>
    /// Origin airport IATA code.
    /// </summary>
    [JsonPropertyName("orig_iata")]
    public string? OriginIATA { get; set; }

    /// <summary>
    /// Origin airport ICAO code.
    /// </summary>
    [JsonPropertyName("orig_icao")]
    public string? OriginICAO { get; set; }

    /// <summary>
    /// Destination airport IATA code.
    /// </summary>
    [JsonPropertyName("dest_iata")]
    public string? DestinationIATA { get; set; }

    /// <summary>
    /// Destination airport ICAO code.
    /// </summary>
    [JsonPropertyName("dest_icao")]
    public string? DestinationICAO { get; set; }

    /// <summary>
    /// Estimated time of arrival.
    /// </summary>
    [JsonPropertyName("eta")]
    public DateTime? EstimatedTimeOfArrival { get; set; }
}