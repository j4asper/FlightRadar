using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IFlightPositionEndpoints
{
    /// <summary>
    /// Returns comprehensive real-time information on aircraft flight movements, including flight and aircraft details such as origin, destination, and aircraft type. At least one query parameter is required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>A read-only list of FlightPositionFull objects.</returns>
    Task<IReadOnlyList<FlightPositionFull>> GetFullAsync(FlightPositionsFilter filter);

    /// <summary>
    /// Returns real-time information on aircraft flight movements including latitude, longitude, speed, and altitude. At least one query parameter is required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>A read-only list of FlightPositionLight objects.</returns>
    Task<IReadOnlyList<FlightPositionLight>> GetAsync(FlightPositionsFilter filter);

    /// <summary>
    /// Returns number of live aircraft flight positions.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>int</returns>
    Task<int> GetCountAsync(FlightPositionsFilter filter);
}