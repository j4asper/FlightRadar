using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class LightAirportResponseModel
{
    [JsonInclude]
    [JsonPropertyName("name")]
    internal string? Name { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("iata")]
    internal string? IataCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("icao")]
    internal required string IcaoCode { get; set; }

    internal virtual AirportLight ToEntityModel()
    {
        return new AirportLight
        {
            Name = Name,
            Code = new Code
            {
                Iata = IataCode,
                Icao = IcaoCode,
            },
        };
    }
}