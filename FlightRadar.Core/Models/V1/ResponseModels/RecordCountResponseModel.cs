using System.Text.Json.Serialization;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class RecordCountResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required List<RecordCountModel> Data { get; set; }
}

internal class RecordCountModel
{
    [JsonInclude]
    [JsonPropertyName("record_count")]
    internal required int RecordCount { get; set; }
}