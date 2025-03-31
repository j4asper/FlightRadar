using System.Text.Json.Serialization;

namespace FlightRadar.Entities.Models.V1;

[JsonConverter(typeof(JsonStringEnumConverter<DataSource>))]
public enum DataSource
{
    ADSB,
    MLAT,
    Estimated
}