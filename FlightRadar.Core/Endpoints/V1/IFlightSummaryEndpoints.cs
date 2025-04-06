using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IFlightSummaryEndpoints
{
    /// <summary>
    /// Returns key timings and locations of aircraft takeoffs and landings alongside all primary flight, aircraft and operator information. Specify either flight_ids or supply both flight_datetime_from and flight_datetime_to along with at least one of the following query parameters - flights, registrations, callsigns, painted_as, operating_as, airports, type, or routes.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>A read-only list of FlightSummaryFull objects.</returns>
    Task<IReadOnlyList<FlightSummaryFull>> GetFullAsync(FlightSummaryFilter filter);

    /// <summary>
    /// Returns key timings and locations of aircraft takeoffs and landings alongside all primary flight, aircraft and operator information. Specify either flight_ids or supply both flight_datetime_from and flight_datetime_to along with at least one of the following query parameters - flights, registrations, callsigns, painted_as, operating_as, airports, type, or routes.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>A read-only list of FlightSummaryLight objects.</returns>
    Task<IReadOnlyList<FlightSummaryLight>> GetAsync(FlightSummaryFilter filter);

    /// <summary>
    /// Returns the number of flights for a given flight summary query.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>int</returns>
    Task<int> GetCountAsync(FlightSummaryFilter filter);
}