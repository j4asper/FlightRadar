using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class FlightPositionLight
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to each flight leg.
    /// </summary>
    [JsonPropertyName("fr24_id")]
    public required string Fr24Id { get; set; }

    /// <summary>
    /// 24 bit Mode-S identifier expressed in hexadecimal format.
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }

    /// <summary>
    /// Callsign used by Air Traffic Control to denote a specific flight (as sent by aircraft transponder).
    /// </summary>
    [JsonPropertyName("callsign")]
    public string? Callsign { get; set; }

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
    /// True track (over ground) expressed in integer degrees as 0-360.
    /// </summary>
    [JsonPropertyName("track")]
    public required int Track { get; set; }

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
    /// 4 digit unique identifying code for ATC expressed in octal format.
    /// </summary>
    [JsonPropertyName("squawk")]
    public required string Squawk { get; set; }

    /// <summary>
    /// Timestamp of the flight position expressed in UTC.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Data source of the provided flight position.
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }
}