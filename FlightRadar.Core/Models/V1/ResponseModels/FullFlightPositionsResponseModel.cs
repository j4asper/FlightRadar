using System.Text.Json.Serialization;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Models.V1.ResponseModels;

internal class FullFlightPositionsResponseModel
{
    [JsonInclude]
    [JsonPropertyName("data")]
    internal required IReadOnlyList<FlightPositionFull> Data { get; set; }
}

internal class FlightPositionFull : FlightPositionLight
{
    [JsonInclude]
    [JsonPropertyName("flight")]
    internal string? FlightNumber { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("type")]
    internal string? AircraftType { get; set; }

    [JsonInclude]
    [JsonPropertyName("reg")]
    internal string? Registration { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("painted_as")]
    internal string? PaintedAs { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("operating_as")]
    internal string? OperatingAs { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("orig_iata")]
    internal string? DepartureIataCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("orig_icao")]
    internal string? DepartureIcaoCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("dest_iata")]
    internal string? DestinationIataCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("dest_icao")]
    internal string? DestinationIcaoCode { get; set; }
    
    [JsonInclude]
    [JsonPropertyName("eta")]
    internal DateTime? EstimatedTimeOfArrival { get; set; }
    
    internal override Entities.Models.V1.FlightPositionFull ToEntityModel()
    {
        return new Entities.Models.V1.FlightPositionFull
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
            OperatingAs = OperatingAs,
            Source = (Entities.Models.V1.DataSource)Enum.Parse(typeof(DataSource), Source.ToString()),
            FlightNumber = FlightNumber,
            AircraftType = AircraftType,
            Registration = Registration,
            PaintedAs = PaintedAs,
            DepartureAirport = DepartureIataCode is not null && DepartureIcaoCode is not null
                ? new Code
                {
                    Icao = DepartureIcaoCode,
                    Iata = DepartureIataCode
                } : null,
            DestinationAirport = DestinationIataCode is not null && DestinationIcaoCode is not null
                ? new Code
                {
                    Icao = DestinationIcaoCode,
                    Iata = DestinationIataCode
                } : null,
            EstimatedTimeOfArrival = EstimatedTimeOfArrival
        };
    }
}