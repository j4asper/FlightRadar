using System.Text.Json.Serialization;

namespace FlightRadar.Core.Models.V1.ResponseModels;

[JsonConverter(typeof(JsonStringEnumConverter<DataSource>))]
public enum DataSource
{
    ADSB,
    MLAT,
    Estimated
}