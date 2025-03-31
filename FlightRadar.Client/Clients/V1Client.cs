using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FlightRadar.Client.Constants;
using FlightRadar.Client.Extensions;
using FlightRadar.Client.Models;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Clients;

public class V1Client : IDisposable
{
    private readonly HttpClient _httpClient;

    public V1Client(string flightRadarApiKey)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(ApiConstants.BaseAddress);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", flightRadarApiKey);
        httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");
        
        _httpClient = httpClient;
    }

    /// <summary>
    /// Returns airline name, ICAO, and IATA codes.
    /// </summary>
    /// <param name="icao">ICAO code of the airline</param>
    /// <returns>Airline?</returns>
    public async Task<Airline?> GetAirlineInfoByIcaoAsync(string icao)
    {
        var response = await _httpClient.GetAsync($"/api/static/airlines/{icao}/light");

        // handle error codes
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<Airline>();
        
        return null;
    }
    
    /// <summary>
    /// Returns details of the requested airport including its name, codes, location, elevation, and timezone information.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>Airport?</returns>
    public async Task<Airport?> GetDetailedAirportInfoByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/light");

        // handle error codes
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<Airport>();
        
        return null;
    }
    
    /// <summary>
    /// Returns the airport name, ICAO and IATA codes.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>AirportDetailed?</returns>
    public async Task<AirportDetailed?> GetAirportInfoByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/full");

        // handle error codes
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<AirportDetailed>();
        
        return null;
    }
    
    
    /// <summary>
    /// Returns a flight with positional tracks for both live and historical flights based on the FR24 flight ID. Availability of historical data depends on the user's subscription plan, with a maximum limit of up to 3 years.
    /// </summary>
    /// <param name="flightId">Id of a flight</param>
    /// <returns>FlightTracks?</returns>
    public async Task<IReadOnlyList<FlightTracks>?> GetFlightTracksByFlightIdAsync(string flightId)
    {
        var response = await _httpClient.GetAsync($"/api/flight-tracks?flight_id={flightId}");

        // handle error codes
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<IReadOnlyList<FlightTracks>>();
        
        return null;
    }
    
    /// <summary>
    /// Get info on API account usage.
    /// </summary>
    /// <param name="timePeriod">The time period for which you want to fetch the usage data.</param>
    /// <returns>IReadOnlyList UsageLogSummary</returns>
    public async Task<IReadOnlyList<UsageLogSummary>?> GetApiUsageAsync(TimePeriod timePeriod = TimePeriod.Last24Hours)
    {
        var response = await _httpClient.GetAsync($"/api/usage?period={timePeriod.GetDescription()}");

        // handle error codes
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<UsageResponseModel>();
            
            return data?.Data;
        }
        
        return null;
    }
    
    public void Dispose() => _httpClient.Dispose();
}