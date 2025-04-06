using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class AirlineResponseModel
{
    [JsonInclude]
    [JsonPropertyName("name")]
    internal required string Name { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("iata")]
    internal string? IataCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("icao")]
    internal required string IcaoCode { get; set; }

    internal Airline ToEntityModel()
    {
        return new Airline
        {
            Name = Name,
            Code = new Code
            {
                Icao = IcaoCode,
                Iata = IataCode
            }
        };
    }
}