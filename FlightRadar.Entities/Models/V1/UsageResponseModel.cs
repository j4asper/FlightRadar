using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class UsageResponseModel
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<UsageLogSummary> Data { get; set; }
}