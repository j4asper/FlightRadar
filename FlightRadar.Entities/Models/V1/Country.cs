using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class Country
{
    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country (e.g., "SE").
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Name of the country (e.g., "SWEDEN").
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}