using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IAirlineEndpoints
{
    /// <summary>
    /// Returns airline name, ICAO, and IATA codes.
    /// </summary>
    /// <param name="icao">ICAO code of the airline</param>
    /// <returns>Airline?</returns>
    Task<Airline?> GetByIcaoCodeAsync(string icao);
}