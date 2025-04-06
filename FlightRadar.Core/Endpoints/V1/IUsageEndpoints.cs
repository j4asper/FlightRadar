using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IUsageEndpoints
{
    /// <summary>
    /// Get info on API account usage.
    /// </summary>
    /// <param name="timePeriod">The time period for which you want to fetch the usage data.</param>
    /// <returns>A read-only list of UsageLogSummary objects.</returns>
    Task<IReadOnlyList<UsageLogSummary>> GetAsync(TimePeriod timePeriod = TimePeriod.Last24Hours);
}