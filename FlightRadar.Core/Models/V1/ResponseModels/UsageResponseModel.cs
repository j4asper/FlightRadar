using System.Text.Json.Serialization;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class UsageResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required IReadOnlyList<UsageLogSummary> Data { get; set; }
}

internal class UsageLogSummary
{
    [JsonInclude]
    [JsonPropertyName("endpoint")]
    internal required string Endpoint { get; set; }

    [JsonInclude]
    [JsonPropertyName("request_count")]
    internal required int RequestCount { get; set; }

    [JsonInclude]
    [JsonPropertyName("credits")]
    internal required int Credits { get; set; }
    
    internal Entities.Models.V1.UsageLogSummary ToEntityModel()
    {
        return new Entities.Models.V1.UsageLogSummary
        {
            Endpoint = Endpoint,
            RequestCount = RequestCount,
            Credits = Credits
        };
    }
}