namespace FlightRadar.Entities.Models.V1;

public class UsageLogSummary
{
    /// <summary>
    /// Endpoint of the API call.
    /// </summary>
    public required string Endpoint { get; set; }

    /// <summary>
    /// Number of requests made to this endpoint.
    /// </summary>
    public required int RequestCount { get; set; }

    /// <summary>
    /// Number of credits used for the API call.
    /// </summary>
    public required int Credits { get; set; }
}