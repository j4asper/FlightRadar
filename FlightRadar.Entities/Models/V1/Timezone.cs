using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class Timezone
{
    /// <summary>
    /// Name of the timezone (e.g., "Europe/Stockholm").
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Offset from UTC in seconds (e.g., 7200).
    /// </summary>
    [JsonPropertyName("offset")]
    public required int Offset { get; set; }
}