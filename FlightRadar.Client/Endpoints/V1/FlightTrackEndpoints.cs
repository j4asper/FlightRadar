using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Models.V1.ResponseModels;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Endpoints.V1;

public class FlightTrackEndpoints : IFlightTrackEndpoints
{
    private readonly HttpClient _httpClient;

    public FlightTrackEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IReadOnlyList<FlightTracks>> GetByFlightIdAsync(string flightId)
    {
        var response = await _httpClient.GetAsync($"/api/flight-tracks?flight_id={flightId}");

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModels = await response.Content.ReadFromJsonAsync<IReadOnlyList<FlightTracksResponseModel>>() ?? [];
            
            return responseModels.Select(flightTracks => flightTracks.ToEntityModel()).ToList();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}