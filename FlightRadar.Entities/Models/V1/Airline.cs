using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class Airline
{
    /// <summary>
    /// Name of the airline.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Airline IATA code.
    /// </summary>
    [JsonPropertyName("iata")]
    public string? IataCode { get; set; }

    /// <summary>
    /// Airline ICAO code.
    /// </summary>
    [JsonPropertyName("icao")]
    public required string IcaoCode { get; set; }
}