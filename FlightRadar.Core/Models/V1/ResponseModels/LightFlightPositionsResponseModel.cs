using System.Text.Json.Serialization;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class LightFlightPositionsResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required IReadOnlyList<FlightPositionLight> Data { get; set; }
}

internal class FlightPositionLight
{
    [JsonInclude]
    [JsonPropertyName("fr24_id")]
    public required string FlightRadar24Id { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("callsign")]
    public string? Callsign { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("lat")]
    public required double Latitude { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("lon")]
    public required double Longitude { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("track")]
    public required int Track { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("alt")]
    public required int Altitude { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("gspeed")]
    public required int GroundSpeed { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("vspeed")]
    public required int VerticalSpeed { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("squawk")]
    public required string Squawk { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("source")]
    public required DataSource Source { get; set; }

    internal virtual Entities.Models.V1.FlightPositionLight ToEntityModel()
    {
        return new Entities.Models.V1.FlightPositionLight
        {
            FlightRadar24Id = FlightRadar24Id,
            Hex = Hex,
            Callsign = Callsign,
            Latitude = Latitude,
            Longitude = Longitude,
            Track = Track,
            Altitude = Altitude,
            GroundSpeed = GroundSpeed,
            VerticalSpeed = VerticalSpeed,
            Squawk = Squawk,
            Timestamp = Timestamp,
            Source = (Entities.Models.V1.DataSource)Enum.Parse(typeof(DataSource), Source.ToString())
        };
    }
}