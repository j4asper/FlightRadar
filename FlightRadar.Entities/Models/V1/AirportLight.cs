using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class AirportLight
{
    /// <summary>
    /// Name of the airport.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Airport IATA code.
    /// </summary>
    [JsonPropertyName("iata")]
    public string? IATA { get; set; }

    /// <summary>
    /// Airport ICAO code.
    /// </summary>
    [JsonPropertyName("icao")]
    public required string ICAO { get; set; }
}