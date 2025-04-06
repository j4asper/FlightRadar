using FlightRadar.Client.Endpoints.V1;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Clients;
using FlightRadar.Core.Constants;
using System.Net.Http.Headers;

namespace FlightRadar.Client.Clients;

public class V1Client : IV1Client
{
    public IAirlineEndpoints Airlines { get; }
    public IAirportEndpoints Airports { get; }
    public IFlightPositionEndpoints FlightPositions { get; }
    public IHistoricFlightPositionEndpoints HistoricFlightPositions { get; }
    public IFlightSummaryEndpoints FlightSummaries { get; }
    public IFlightTrackEndpoints FlightTracks { get; }
    public IUsageEndpoints Usage { get; }
    
    private readonly HttpClient _httpClient;
    
    public V1Client(string flightRadarApiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ApiConstants.BaseAddress);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", flightRadarApiKey);
        _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");
        
        Airlines = new AirlineEndpoints(_httpClient);
        Airports = new AirportEndpoints(_httpClient);
        FlightPositions = new FlightPositionEndpoints(_httpClient);
        HistoricFlightPositions = new HistoricFlightPositionEndpoints(_httpClient);
        FlightSummaries = new FlightSummaryEndpoints(_httpClient);
        FlightTracks = new FlightTrackEndpoints(_httpClient);
        Usage = new UsageEndpoints(_httpClient);
    }
    
    public void Dispose() => _httpClient.Dispose();
}