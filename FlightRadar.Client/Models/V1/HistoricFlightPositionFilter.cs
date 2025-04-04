namespace FlightRadar.Client.Models.V1;

public class HistoricFlightPositionFilter : FlightPositionsFilter
{
    /// <summary>
    /// Datetime representing the exact point in time for which you want to fetch flight positions. The datetime must be later than May 11, 2016, subject to your subscription plan's limitations.
    /// </summary>
    /// <remarks>Must be later than May 11, 2016</remarks>
    public required DateTime Timestamp { get; set; }

    public override string ToString()
    {
        var withoutTimestamp = base.ToString();

        var unixTimestamp = ((DateTimeOffset)Timestamp).ToUnixTimeSeconds();
        
        return withoutTimestamp + $"&timestamp={unixTimestamp}";
    }
}