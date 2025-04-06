namespace FlightRadar.Entities.Models.V1;

public class FlightPositionLight
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to each flight leg.
    /// </summary>
    public required string FlightRadar24Id { get; set; }

    /// <summary>
    /// 24 bit Mode-S identifier expressed in hexadecimal format.
    /// </summary>
    public string? Hex { get; set; }

    /// <summary>
    /// Callsign used by Air Traffic Control to denote a specific flight (as sent by aircraft transponder).
    /// </summary>
    public string? Callsign { get; set; }

    /// <summary>
    /// Latest latitude expressed in decimal degrees.
    /// </summary>
    public required double Latitude { get; set; }

    /// <summary>
    /// Latest longitude expressed in decimal degrees.
    /// </summary>
    public required double Longitude { get; set; }

    /// <summary>
    /// True track (over ground) expressed in integer degrees as 0-360.
    /// </summary>
    public required int Track { get; set; }

    /// <summary>
    /// Barometric pressure altitude above mean sea level (AMSL) expressed in feet.
    /// </summary>
    public required int Altitude { get; set; }

    /// <summary>
    /// Speed relative to the ground expressed in knots.
    /// </summary>
    public required int GroundSpeed { get; set; }

    /// <summary>
    /// The rate at which the aircraft is ascending or descending in feet per minute.
    /// </summary>
    public required int VerticalSpeed { get; set; }

    /// <summary>
    /// 4 digit unique identifying code for ATC expressed in octal format.
    /// </summary>
    public required string Squawk { get; set; }

    /// <summary>
    /// Timestamp of the flight position expressed in UTC.
    /// </summary>
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Data source of the provided flight position.
    /// </summary>
    public required DataSource Source { get; set; }
}