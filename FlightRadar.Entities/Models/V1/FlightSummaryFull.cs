using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightSummaryFull : FlightSummaryLight
{
    /// <summary>
    /// Origin airport IATA code.
    /// </summary>
    [JsonPropertyName("orig_iata")]
    public string? DepartureIataCode { get; set; }

    /// <summary>
    /// Identifier of the runway used for takeoff.
    /// </summary>
    [JsonPropertyName("runway_takeoff")]
    public string? RunwayTakeoff { get; set; }

    /// <summary>
    /// Destination airport IATA code.
    /// </summary>
    [JsonPropertyName("dest_iata")]
    public string? DestinationIataCode { get; set; }

    /// <summary>
    /// ICAO code for the actual destination airport (different when diverted).
    /// </summary>
    [JsonPropertyName("dest_icao_actual")]
    public string? ActualDestinationIcaoCode { get; set; }

    /// <summary>
    /// IATA code for the actual destination airport (different when diverted).
    /// </summary>
    [JsonPropertyName("dest_iata_actual")]
    public string? ActualDestinationIataCode { get; set; }

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
}