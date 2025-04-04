using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Models.V1.ResponseModels;

public class FullFlightPositionsResponseModel
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<FlightPositionFull> Data { get; set; }
}