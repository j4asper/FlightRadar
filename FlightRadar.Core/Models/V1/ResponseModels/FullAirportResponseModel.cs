using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class FullAirportResponseModel : LightAirportResponseModel
{
    [JsonInclude]
    [JsonPropertyName("lon")]
    internal required double Longitude { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("lat")]
    internal required double Latitude { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("elevation")]
    internal required int Elevation { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("country")]
    internal required Country Country { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("city")]
    internal required string City { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("state")]
    internal string? State { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("timezone")]
    internal required Timezone Timezone { get; set; }

    internal override AirportFull ToEntityModel()
    {
        return new AirportFull
        {
            Name = Name,
            Code = new Code
            {
                Iata = IataCode,
                Icao = IcaoCode,
            },
            Longitude = Longitude,
            Latitude = Latitude,
            Elevation = Elevation,
            Country = new Entities.Models.V1.Country
            {
                Name = Country.Name,
                Code = Country.Code,
            },
            City = City,
            State = State,
            Timezone = new Entities.Models.V1.Timezone
            {
                Name = Timezone.Name,
                Offset = Timezone.Offset,
            }
        };
    }
}

internal class Country
{
    [JsonPropertyName("code")]
    internal required string Code { get; set; }

    [JsonPropertyName("name")]
    internal required string Name { get; set; }
}

internal class Timezone
{
    [JsonPropertyName("name")]
    internal required string Name { get; set; }

    [JsonPropertyName("offset")]
    internal required int Offset { get; set; }
}