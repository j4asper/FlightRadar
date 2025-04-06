using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Core.Models.V1.ResponseModels;
using FlightSummaryFull = FlightRadar.Entities.Models.V1.FlightSummaryFull;
using FlightSummaryLight = FlightRadar.Entities.Models.V1.FlightSummaryLight;

namespace FlightRadar.Client.Endpoints.V1;

public class FlightSummaryEndpoints : IFlightSummaryEndpoints
{
    private readonly HttpClient _httpClient;

    public FlightSummaryEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IReadOnlyList<FlightSummaryFull>> GetFullAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/full?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<FullFlightSummaryResponseModel>()
                                ?? new FullFlightSummaryResponseModel { Data = [] };
            
            return responseModel.Data.Select(x => x.ToEntityModel()).ToList();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }

    public async Task<IReadOnlyList<FlightSummaryLight>> GetAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/light?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<LightFlightSummaryResponseModel>()
                                ?? new LightFlightSummaryResponseModel { Data = [] };
            
            return responseModel.Data.Select(x => x.ToEntityModel()).ToList();
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }

    public async Task<int> GetCountAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/count?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<RecordCountResponseModel>();

            return data?.Data.First().RecordCount ?? 0;
        }
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}