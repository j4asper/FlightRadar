using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class FlightTracksResponseModel
{
    [JsonInclude]
    [JsonPropertyName("fr24_id")]
    internal required string FlightRadar24Id { get; set; }

    [JsonInclude]
    [JsonPropertyName("tracks")]
    internal required IReadOnlyList<FlightTrack> Tracks { get; set; }

    internal FlightTracks ToEntityModel()
    {
        return new FlightTracks
        {
            FlightRadar24Id = FlightRadar24Id,
            Tracks = Tracks.Select(track => track.ToEntityModel()).ToList(),
        };
    }
}

internal class FlightTrack
{
    [JsonInclude]
    [JsonPropertyName("timestamp")]
    internal required DateTime Timestamp { get; set; }

    [JsonInclude]
    [JsonPropertyName("lat")]
    internal required double Latitude { get; set; }

    [JsonInclude]
    [JsonPropertyName("lon")]
    internal required double Longitude { get; set; }

    [JsonInclude]
    [JsonPropertyName("alt")]
    internal required int Altitude { get; set; }

    [JsonInclude]
    [JsonPropertyName("gspeed")]
    internal required int GroundSpeed { get; set; }

    [JsonInclude]
    [JsonPropertyName("vspeed")]
    internal required int VerticalSpeed { get; set; }

    [JsonInclude]
    [JsonPropertyName("track")]
    internal required int Track { get; set; }

    [JsonInclude]
    [JsonPropertyName("squawk")]
    internal required string Squawk { get; set; }

    [JsonInclude]
    [JsonPropertyName("callsign")]
    internal string? Callsign { get; set; }

    [JsonInclude]
    [JsonPropertyName("source")]
    internal required DataSource Source { get; set; }
    
    internal Entities.Models.V1.FlightTrack ToEntityModel()
    {
        return new Entities.Models.V1.FlightTrack
        {
            Timestamp = Timestamp,
            Latitude = Latitude,
            Longitude = Longitude,
            Altitude = Altitude,
            GroundSpeed = GroundSpeed,
            VerticalSpeed = VerticalSpeed,
            Track = Track,
            Squawk = Squawk,
            Callsign = Callsign,
            Source = (Entities.Models.V1.DataSource)Enum.Parse(typeof(DataSource), Source.ToString()),
        };
    }
}