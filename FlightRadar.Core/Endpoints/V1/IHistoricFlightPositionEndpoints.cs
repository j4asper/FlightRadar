using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IHistoricFlightPositionEndpoints
{
    /// <summary>
    /// Returns comprehensive historical information on aircraft flight movements, including flight and aircraft details such as origin, destination, and aircraft type, dating back to May 11, 2016. At least one query parameter and a history snapshot timestamp are required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>A read-only list of FlightPositionFull objects.</returns>
    Task<IReadOnlyList<FlightPositionFull>> GetFullAsync(HistoricFlightPositionFilter filter);

    /// <summary>
    /// Returns historical information on aircraft flight movements including latitude, longitude, speed, and altitude, dating back to May 11, 2016. At least one query parameter and a history snapshot timestamp are required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>A read-only list of FlightPositionLight objects.</returns>
    Task<IReadOnlyList<FlightPositionLight>> GetAsync(HistoricFlightPositionFilter filter);

    /// <summary>
    /// Returns number of historical aircraft flight positions.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>int</returns>
    Task<int> GetCountAsync(HistoricFlightPositionFilter filter);
}