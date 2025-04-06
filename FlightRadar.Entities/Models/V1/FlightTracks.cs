namespace FlightRadar.Entities.Models.V1;

public class FlightTracks
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to the flight leg.
    /// </summary>
    public required string FlightRadar24Id { get; set; }

    /// <summary>
    /// List of flight tracks with position and other details.
    /// </summary>
    public required IReadOnlyList<FlightTrack> Tracks { get; set; }
}

public class FlightTrack
{
    /// <summary>
    /// Timestamp of the flight position expressed in UTC.
    /// </summary>
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Latest latitude expressed in decimal degrees.
    /// </summary>
    public required double Latitude { get; set; }

    /// <summary>
    /// Latest longitude expressed in decimal degrees.
    /// </summary>
    public required double Longitude { get; set; }

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
    /// True track (over ground) expressed in integer degrees as 0-360.
    /// </summary>
    public required int Track { get; set; }

    /// <summary>
    /// 4 digit unique identifying code for ATC expressed in octal format.
    /// </summary>
    public required string Squawk { get; set; }

    /// <summary>
    /// The last known callsign used by Air Traffic Control to denote a specific flight.
    /// </summary>
    public string? Callsign { get; set; }

    /// <summary>
    /// Data source of the provided flight position.
    /// </summary>
    public required DataSource Source { get; set; }
}