using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class AirportFull : AirportLight
{
    /// <summary>
    /// Longitude expressed in decimal degrees.
    /// </summary>
    [JsonPropertyName("lon")]
    public required double Longitude { get; set; }

    /// <summary>
    /// Latitude expressed in decimal degrees.
    /// </summary>
    [JsonPropertyName("lat")]
    public required double Latitude { get; set; }

    /// <summary>
    /// Airport elevation in feet (e.g., 150).
    /// </summary>
    [JsonPropertyName("elevation")]
    public required int Elevation { get; set; }

    /// <summary>
    /// Country information.
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; set; }

    /// <summary>
    /// City where the airport is located (e.g., "Stockholm").
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// State where the airport is located (nullable, only available for certain countries).
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Timezone information.
    /// </summary>
    [JsonPropertyName("timezone")]
    public required Timezone Timezone { get; set; }
}