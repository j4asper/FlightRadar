using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Models.V1.ResponseModels;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Endpoints.V1;

public class AirportEndpoints : IAirportEndpoints
{
    private readonly HttpClient _httpClient;

    public AirportEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<AirportLight?> GetByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/light");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<LightAirportResponseModel>();

            return responseModel?.ToEntityModel();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }

    public async Task<AirportFull?> GetFullByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/full");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<FullAirportResponseModel>();

            return responseModel?.ToEntityModel();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}