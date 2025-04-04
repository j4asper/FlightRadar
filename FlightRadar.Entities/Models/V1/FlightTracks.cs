using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightTracks
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to the flight leg.
    /// </summary>
    [JsonPropertyName("fr24_id")]
    public required string FlightRadar24Id { get; set; }

    /// <summary>
    /// List of flight tracks with position and other details.
    /// </summary>
    [JsonPropertyName("tracks")]
    public required IReadOnlyList<FlightTrack> Tracks { get; set; }
}

public class FlightTrack
{
    /// <summary>
    /// Timestamp of the flight position expressed in UTC.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Latest latitude expressed in decimal degrees.
    /// </summary>
    [JsonPropertyName("lat")]
    public required double Latitude { get; set; }

    /// <summary>
    /// Latest longitude expressed in decimal degrees.
    /// </summary>
    [JsonPropertyName("lon")]
    public required double Longitude { get; set; }

    /// <summary>
    /// Barometric pressure altitude above mean sea level (AMSL) expressed in feet.
    /// </summary>
    [JsonPropertyName("alt")]
    public required int Altitude { get; set; }

    /// <summary>
    /// Speed relative to the ground expressed in knots.
    /// </summary>
    [JsonPropertyName("gspeed")]
    public required int GroundSpeed { get; set; }

    /// <summary>
    /// The rate at which the aircraft is ascending or descending in feet per minute.
    /// </summary>
    [JsonPropertyName("vspeed")]
    public required int VerticalSpeed { get; set; }

    /// <summary>
    /// True track (over ground) expressed in integer degrees as 0-360.
    /// </summary>
    [JsonPropertyName("track")]
    public required int Track { get; set; }

    /// <summary>
    /// 4 digit unique identifying code for ATC expressed in octal format.
    /// </summary>
    [JsonPropertyName("squawk")]
    public required string Squawk { get; set; }

    /// <summary>
    /// The last known callsign used by Air Traffic Control to denote a specific flight.
    /// </summary>
    [JsonPropertyName("callsign")]
    public string? Callsign { get; set; }

    /// <summary>
    /// Data source of the provided flight position.
    /// </summary>
    [JsonPropertyName("source")]
    public required DataSource Source { get; set; }
}