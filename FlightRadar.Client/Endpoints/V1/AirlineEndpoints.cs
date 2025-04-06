using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Models.V1.ResponseModels;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Endpoints.V1;

public class AirlineEndpoints : IAirlineEndpoints
{
    private readonly HttpClient _httpClient;

    public AirlineEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Airline?> GetByIcaoCodeAsync(string icao)
    {
        var response = await _httpClient.GetAsync($"/api/static/airlines/{icao}/light");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<AirlineResponseModel>();
            
            return responseModel?.ToEntityModel();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}