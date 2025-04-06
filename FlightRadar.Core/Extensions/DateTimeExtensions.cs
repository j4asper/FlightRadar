namespace FlightRadar.Core.Extensions;

internal static class DateTimeExtensions
{
    internal static string ToUniversalIso8601(this DateTime dateTime)
    {
        return dateTime.ToString("u").Replace(" ", "T");
    }
}