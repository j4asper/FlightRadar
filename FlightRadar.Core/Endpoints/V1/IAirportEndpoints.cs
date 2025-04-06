using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Core.Endpoints.V1;

public interface IAirportEndpoints
{
    /// <summary>
    /// Returns the airport name, ICAO and IATA codes. For more details, use <b>GetFullByCodeAsync</b>.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>Airport?</returns>
    Task<AirportLight?> GetByCodeAsync(string code);

    /// <summary>
    /// Returns details of the requested airport including its name, codes, location, elevation, and timezone information. For less details, use <b>GetByCodeAsync</b>.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>AirportFull?</returns>
    Task<AirportFull?> GetFullByCodeAsync(string code);
}