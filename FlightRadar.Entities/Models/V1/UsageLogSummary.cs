using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class UsageLogSummary
{
    /// <summary>
    /// Endpoint of the API call.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public required string Endpoint { get; set; }

    /// <summary>
    /// Number of requests made to this endpoint.
    /// </summary>
    [JsonPropertyName("request_count")]
    public required int RequestCount { get; set; }

    /// <summary>
    /// Number of credits used for the API call.
    /// </summary>
    [JsonPropertyName("credits")]
    public required int Credits { get; set; }
}