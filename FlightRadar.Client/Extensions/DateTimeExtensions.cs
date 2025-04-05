namespace FlightRadar.Client.Extensions;

public static class DateTimeExtensions
{
    public static string ToUniversalIso8601(this DateTime dateTime)
    {
        return dateTime.ToString("u").Replace(" ", "T");
    }
}