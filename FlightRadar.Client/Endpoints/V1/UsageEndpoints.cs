using System.Net;
using System.Net.Http.Json;
using FlightRadar.Client.Exceptions;
using FlightRadar.Core.Endpoints.V1;
using FlightRadar.Core.Extensions;
using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Core.Models.V1.ResponseModels;
using UsageLogSummary = FlightRadar.Entities.Models.V1.UsageLogSummary;

namespace FlightRadar.Client.Endpoints.V1;

public class UsageEndpoints : IUsageEndpoints
{
    private readonly HttpClient _httpClient;

    public UsageEndpoints(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IReadOnlyList<UsageLogSummary>> GetAsync(TimePeriod timePeriod = TimePeriod.Last24Hours)
    {
        var response = await _httpClient.GetAsync($"/api/usage?period={timePeriod.GetDescription()}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<UsageResponseModel>()
                                ?? new UsageResponseModel { Data = [] };
            
            return responseModel.Data.Select(x => x.ToEntityModel()).ToList();
        }
        
        throw await ApiExceptionHandler.ThrowOnUnexpectedResponse(response);
    }
}