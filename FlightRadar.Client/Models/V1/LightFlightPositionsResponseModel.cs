using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Models.V1;

public class LightFlightPositionsResponseModel
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<FlightPosition> Data { get; set; }
}