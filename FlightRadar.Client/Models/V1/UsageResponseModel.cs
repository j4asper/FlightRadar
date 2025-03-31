using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Models.V1;

public class UsageResponseModel
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<UsageLogSummary> Data { get; set; }
}