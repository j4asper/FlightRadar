using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

public class Flight
{
    /// <summary>
    /// Unique identifier assigned by Flightradar24 to each flight leg.
    /// </summary>
    [JsonPropertyName("fr24_id")]
    public required string Fr24Id { get; set; }

    /// <summary>
    /// Commercial flight number.
    /// </summary>
    [JsonPropertyName("flight")]
    public string? FlightNumber { get; set; }

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
    /// True track (over ground) expressed in integer degrees as 0-360. Please note that 0 can in some cases mean unknown.
    /// </summary>
    [JsonPropertyName("track")]
    public required int Track { get; set; }

    /// <summary>
    /// Barometric pressure altitude above mean sea level (AMSL) reported at a standard atmospheric pressure (1013.25 hPa / 29.92 in. Hg.) expressed in feet.
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

    /// <summary>
    /// 24 bit Mode-S identifier expressed in hexadecimal format.
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }

    /// <summary>
    /// Aircraft ICAO type code.
    /// </summary>
    [JsonPropertyName("type")]
    public string? AircraftType { get; set; }

    /// <summary>
    /// Aircraft registration as matched from Mode-S identifier.
    /// </summary>
    [JsonPropertyName("reg")]
    public string? Registration { get; set; }

    /// <summary>
    /// ICAO code of the carrier mapped from FR24's internal database.
    /// </summary>
    [JsonPropertyName("painted_as")]
    public string? PaintedAs { get; set; }

    /// <summary>
    /// ICAO code of the airline carrier as derived from flight callsign.
    /// </summary>
    [JsonPropertyName("operating_as")]
    public string? OperatingAs { get; set; }

    /// <summary>
    /// Origin airport IATA code.
    /// </summary>
    [JsonPropertyName("orig_iata")]
    public string? OriginIATA { get; set; }

    /// <summary>
    /// Origin airport ICAO code.
    /// </summary>
    [JsonPropertyName("orig_icao")]
    public string? OriginICAO { get; set; }

    /// <summary>
    /// Destination airport IATA code.
    /// </summary>
    [JsonPropertyName("dest_iata")]
    public string? DestinationIATA { get; set; }

    /// <summary>
    /// Destination airport ICAO code.
    /// </summary>
    [JsonPropertyName("dest_icao")]
    public string? DestinationICAO { get; set; }

    /// <summary>
    /// Estimated time of arrival.
    /// </summary>
    [JsonPropertyName("eta")]
    public DateTime? EstimatedTimeOfArrival { get; set; }
}