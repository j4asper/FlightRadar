using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IFlightTrackEndpoints
{
    /// <summary>
    /// Returns a flight with positional tracks for both live and historical flights based on the FR24 flight ID. Availability of historical data depends on the user's subscription plan, with a maximum limit of up to 3 years.
    /// </summary>
    /// <param name="flightId">FlightRadar24 specific Id of a flight</param>
    /// <returns>A read-only list of FlightTracks objects.</returns>
    Task<IReadOnlyList<FlightTracks>> GetByFlightIdAsync(string flightId);
}