using System.Text.Json.Serialization;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class ErrorResponseModel
{
    [JsonInclude]
    internal required string Message { get; set; }
    
    [JsonInclude]
    internal string? Details { get; set; }
}