using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class LightFlightSummaryResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required IReadOnlyList<FlightSummaryLight> Data { get; set; }
}

internal class FlightSummaryLight
{
    [JsonInclude]
    [JsonPropertyName("fr24_id")]
    internal required string FlightRadar24Id { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("flight")]
    internal string? FlightNumber { get; set; }

    [JsonInclude]
    [JsonPropertyName("callsign")]
    internal string? Callsign { get; set; }

    [JsonInclude]
    [JsonPropertyName("operating_as")]
    internal string? OperatingAs { get; set; }

    [JsonInclude]
    [JsonPropertyName("painted_as")]
    internal string? PaintedAs { get; set; }

    [JsonInclude]
    [JsonPropertyName("type")]
    internal string? AircraftType { get; set; }

    [JsonInclude]
    [JsonPropertyName("reg")]
    internal string? Registration { get; set; }

    [JsonInclude]
    [JsonPropertyName("orig_icao")]
    internal string? DepartureIcaoCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("datetime_takeoff")]
    internal DateTime? TakeoffTime { get; set; }

    [JsonInclude]
    [JsonPropertyName("dest_icao")]
    internal string? DestinationIcaoCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("datetime_landed")]
    internal DateTime? LandingTime { get; set; }

    [JsonInclude]
    [JsonPropertyName("hex")]
    internal string? Hex { get; set; }

    [JsonInclude]
    [JsonPropertyName("first_seen")]
    internal DateTime? FirstSeen { get; set; }

    [JsonInclude]
    [JsonPropertyName("last_seen")]
    internal DateTime? LastSeen { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("flight_ended")]
    internal bool? FlightEnded { get; set; }

    internal virtual Entities.Models.V1.FlightSummaryLight ToEntityModel()
    {
        return new Entities.Models.V1.FlightSummaryLight
        {
            FlightRadar24Id = FlightRadar24Id,
            FlightNumber = FlightNumber,
            Callsign = Callsign,
            OperatingAs = OperatingAs,
            PaintedAs = PaintedAs,
            AircraftType = AircraftType,
            Registration = Registration,
            DepartureAirport = DepartureIcaoCode is not null
                ? new Code
                {
                    Icao = DepartureIcaoCode
                }
                : null,
            DestinationAirport = DestinationIcaoCode is not null
                ? new Code
                {
                    Icao = DestinationIcaoCode
                }
                : null,
            TakeoffTime = TakeoffTime,
            LandingTime = LandingTime,
            Hex = Hex,
            FirstSeen = FirstSeen,
            LastSeen = LastSeen,
            IsLive = !FlightEnded,
        };
    }
}