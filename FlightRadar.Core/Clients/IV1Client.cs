using FlightRadar.Core.Endpoints.V1;

namespace FlightRadar.Core.Clients;

public interface IV1Client : IDisposable
{
    /// <summary>
    /// All Airline endpoints
    /// </summary>
    IAirlineEndpoints Airlines { get; }
    
    /// <summary>
    /// All Airport endpoints
    /// </summary>
    IAirportEndpoints Airports { get; }
    
    /// <summary>
    /// All Flight Position endpoints
    /// </summary>
    IFlightPositionEndpoints FlightPositions { get; }
    
    /// <summary>
    /// All Historic Flight Position endpoints
    /// </summary>
    IHistoricFlightPositionEndpoints HistoricFlightPositions { get; }
    
    /// <summary>
    /// All Flight Summary endpoints
    /// </summary>
    IFlightSummaryEndpoints FlightSummaries { get; }
    
    /// <summary>
    /// All Flight Track endpoints
    /// </summary>
    IFlightTrackEndpoints FlightTracks { get; }
    
    /// <summary>
    /// All Usage endpoints
    /// </summary>
    IUsageEndpoints Usage { get; }
}