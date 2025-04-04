using System.Text.Json.Serialization;

namespace FlightRadar.Client.Models.V1.ResponseModels;

public class FlightPositionsCountResponseModel
{
    [JsonPropertyName("data")]
    public required List<RecordCountModel> Data { get; set; }
}

public class RecordCountModel
{
    [JsonPropertyName("record_count")]
    public required int RecordCount { get; set; }
}