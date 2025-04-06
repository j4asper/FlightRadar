using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class FullFlightSummaryResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required IReadOnlyList<FlightSummaryFull> Data { get; set; }
}

internal class FlightSummaryFull : FlightSummaryLight
{
    [JsonInclude]
    [JsonPropertyName("orig_iata")]
    internal string? DepartureIataCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("runway_takeoff")]
    internal string? RunwayTakeoff { get; set; }

    [JsonInclude]
    [JsonPropertyName("dest_iata")]
    internal string? DestinationIataCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("dest_icao_actual")]
    internal string? ActualDestinationIcaoCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("dest_iata_actual")]
    internal string? ActualDestinationIataCode { get; set; }

    [JsonInclude]
    [JsonPropertyName("runway_landed")]
    internal string? RunwayLanded { get; set; }

    [JsonInclude]
    [JsonPropertyName("flight_time")]
    internal int? FlightTime { get; set; }

    [JsonInclude]
    [JsonPropertyName("actual_distance")]
    internal float? ActualDistance { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("circle_distance")]
    internal float? CircleDistance { get; set; }
    
    internal override Entities.Models.V1.FlightSummaryFull ToEntityModel()
    {
        return new Entities.Models.V1.FlightSummaryFull
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
                    Icao = DepartureIcaoCode,
                    Iata = DepartureIataCode
                }
                : null,
            DestinationAirport = DestinationIcaoCode is not null
                ? new Code
                {
                    Icao = DestinationIcaoCode,
                    Iata = DestinationIataCode
                }
                : null,
            ActualDestinationAirport = ActualDestinationIataCode is not null && ActualDestinationIcaoCode is not null
                ? new Code
                {
                    Icao = ActualDestinationIcaoCode,
                    Iata = ActualDestinationIataCode
                } : null,
            TakeoffTime = TakeoffTime,
            LandingTime = LandingTime,
            Hex = Hex,
            FirstSeen = FirstSeen,
            LastSeen = LastSeen,
            IsLive = !FlightEnded,
            RunwayTakeoff = RunwayTakeoff,
            RunwayLanded = RunwayLanded,
            ActualDistance = ActualDistance,
            CircleDistance = CircleDistance,
            FlightTime = FlightTime.HasValue ? TimeSpan.FromSeconds(FlightTime.Value) : null,
        };
    }
}