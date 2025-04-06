using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Core.Models.V1.ResponseModels;
using FlightPositionFull = FlightRadar.Entities.Models.V1.FlightPositionFull;
using FlightPositionLight = FlightRadar.Entities.Models.V1.FlightPositionLight;

namespace FlightRadar.Client.Endpoints.V1;

public class HistoricFlightPositionEndpoints : IHistoricFlightPositionEndpoints
{
    private readonly HttpClient _httpClient;

    public HistoricFlightPositionEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IReadOnlyList<FlightPositionFull>> GetFullAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/historic/flight-positions/full?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<FullFlightPositionsResponseModel>()
                                ?? new FullFlightPositionsResponseModel { Data = [] };
            
            return responseModel.Data.Select(x => x.ToEntityModel()).ToList();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }

    public async Task<IReadOnlyList<FlightPositionLight>> GetAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/historic/flight-positions/light?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<LightFlightPositionsResponseModel>()
                                ?? new LightFlightPositionsResponseModel { Data = [] };

            return responseModel.Data.Select(x => x.ToEntityModel()).ToList();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }

    public async Task<int> GetCountAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/live/flight-positions/count?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<RecordCountResponseModel>();

            return data?.Data.First().RecordCount ?? 0;
        }
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}