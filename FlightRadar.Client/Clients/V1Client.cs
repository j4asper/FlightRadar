using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FlightRadar.Client.Constants;
using FlightRadar.Client.Exceptions;
using FlightRadar.Client.Extensions;
using FlightRadar.Client.Models.V1;
using FlightRadar.Client.Models.V1.ResponseModels;
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

    # region Airline Endpoints
    
    /// <summary>
    /// Returns airline name, ICAO, and IATA codes.
    /// </summary>
    /// <param name="icao">ICAO code of the airline</param>
    /// <returns>Airline?</returns>
    public async Task<Airline?> GetAirlineInfoByIcaoAsync(string icao)
    {
        var response = await _httpClient.GetAsync($"/api/static/airlines/{icao}/light");
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<Airline>();
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Airport Endpoints
    
    /// <summary>
    /// Returns details of the requested airport including its name, codes, location, elevation, and timezone information.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>Airport?</returns>
    public async Task<AirportLight?> GetAirportInfoByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/light");
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<AirportLight>();
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns the airport name, ICAO and IATA codes.
    /// </summary>
    /// <param name="code">ICAO or IATA code of the airport</param>
    /// <returns>AirportFull?</returns>
    public async Task<AirportFull?> GetDetailedAirportInfoByCodeAsync(string code)
    {
        var response = await _httpClient.GetAsync($"/api/static/airports/{code}/full");
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<AirportFull>();
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Flight Position Endpoints
    
    /// <summary>
    /// Returns comprehensive real-time information on aircraft flight movements, including flight and aircraft details such as origin, destination, and aircraft type. At least one query parameter is required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>A read-only list of FlightPositionFull objects.</returns>
    public async Task<IReadOnlyList<FlightPositionFull>> GetFullFlightPositionsAsync(FlightPositionsFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/live/flight-positions/full?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<FullFlightPositionsResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns real-time information on aircraft flight movements including latitude, longitude, speed, and altitude. At least one query parameter is required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>A read-only list of FlightPositionLight objects.</returns>
    public async Task<IReadOnlyList<FlightPositionLight>> GetFlightPositionsAsync(FlightPositionsFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/live/flight-positions/light?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<LightFlightPositionsResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns number of live aircraft flight positions.
    /// </summary>
    /// <param name="filter">Filter to use for the flight positions result</param>
    /// <returns>int</returns>
    public async Task<int> GetFlightPositionsCountAsync(FlightPositionsFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/live/flight-positions/count?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<RecordCountResponseModel>();

            return data?.Data.First().RecordCount ?? 0;
        }
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Historic Flight Position Endpoints
    
    /// <summary>
    /// Returns comprehensive historical information on aircraft flight movements, including flight and aircraft details such as origin, destination, and aircraft type, dating back to May 11, 2016. At least one query parameter and a history snapshot timestamp are required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>A read-only list of FlightPositionFull objects.</returns>
    public async Task<IReadOnlyList<FlightPositionFull>> GetFullHistoricFlightPositionsAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/historic/flight-positions/full?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<FullFlightPositionsResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns historical information on aircraft flight movements including latitude, longitude, speed, and altitude, dating back to May 11, 2016. At least one query parameter and a history snapshot timestamp are required to retrieve data.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>A read-only list of FlightPositionLight objects.</returns>
    public async Task<IReadOnlyList<FlightPositionLight>> GetHistoricFlightPositionsAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/historic/flight-positions/light?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<LightFlightPositionsResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns number of historical aircraft flight positions.
    /// </summary>
    /// <param name="filter">Filter to use for the historic flight positions result</param>
    /// <returns>int</returns>
    public async Task<int> GetHistoricFlightPositionsCountAsync(HistoricFlightPositionFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/live/flight-positions/count?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<RecordCountResponseModel>();

            return data?.Data.First().RecordCount ?? 0;
        }
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Flight Summary Endpoints
    
    /// <summary>
    /// Returns key timings and locations of aircraft takeoffs and landings alongside all primary flight, aircraft and operator information. Specify either flight_ids or supply both flight_datetime_from and flight_datetime_to along with at least one of the following query parameters - flights, registrations, callsigns, painted_as, operating_as, airports, type, or routes.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>A read-only list of FlightSummaryFull objects.</returns>
    public async Task<IReadOnlyList<FlightSummaryFull>> GetFullFlightSummaryAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/full?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<FullFlightSummaryResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns key timings and locations of aircraft takeoffs and landings alongside all primary flight, aircraft and operator information. Specify either flight_ids or supply both flight_datetime_from and flight_datetime_to along with at least one of the following query parameters - flights, registrations, callsigns, painted_as, operating_as, airports, type, or routes.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>A read-only list of FlightSummaryLight objects.</returns>
    public async Task<IReadOnlyList<FlightSummaryLight>> GetFlightSummaryAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/light?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<LightFlightSummaryResponseModel>();

            return data?.Data ?? [];
        }
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    /// <summary>
    /// Returns the number of flights for a given flight summary query.
    /// </summary>
    /// <param name="filter">Filter to use for the flight summary result</param>
    /// <returns>int</returns>
    public async Task<int> GetFlightSummaryCountAsync(FlightSummaryFilter filter)
    {
        var response = await _httpClient.GetAsync($"/api/flight-summary/count?{filter}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<RecordCountResponseModel>();

            return data?.Data.First().RecordCount ?? 0;
        }
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Flight Tracks Endpoints
    
    /// <summary>
    /// Returns a flight with positional tracks for both live and historical flights based on the FR24 flight ID. Availability of historical data depends on the user's subscription plan, with a maximum limit of up to 3 years.
    /// </summary>
    /// <param name="flightId">Id of a flight</param>
    /// <returns>A read-only list of FlightTracks objects.</returns>
    public async Task<IReadOnlyList<FlightTracks>> GetFlightTracksByFlightIdAsync(string flightId)
    {
        var response = await _httpClient.GetAsync($"/api/flight-tracks?flight_id={flightId}");
        
        if (response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<IReadOnlyList<FlightTracks>>() ?? [];
        
        if (response.StatusCode == HttpStatusCode.NotFound)
            return [];
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    # region Usage Endpoints
    
    /// <summary>
    /// Get info on API account usage.
    /// </summary>
    /// <param name="timePeriod">The time period for which you want to fetch the usage data.</param>
    /// <returns>A read-only list of UsageLogSummary objects.</returns>
    public async Task<IReadOnlyList<UsageLogSummary>> GetApiUsageAsync(TimePeriod timePeriod = TimePeriod.Last24Hours)
    {
        var response = await _httpClient.GetAsync($"/api/usage?period={timePeriod.GetDescription()}");
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var data = await response.Content.ReadFromJsonAsync<UsageResponseModel>();
            
            return data?.Data ?? [];
        }
        
        throw await ThrowOnUnexpectedResponse(response);
    }
    
    # endregion
    
    private async Task<Exception> ThrowOnUnexpectedResponse(HttpResponseMessage response)
    {
        var errorDetails = await response.Content.ReadFromJsonAsync<ErrorResponseModel>();

        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new ValidationException(errorDetails?.Details ?? "Validation failed."),
            HttpStatusCode.Unauthorized => new UnauthenticatedException(errorDetails?.Details ?? "The FlightRadar24 API Key is invalid."),
            HttpStatusCode.PaymentRequired => new PaymentRequiredException(errorDetails?.Details ?? "Credit limit reached. Please top up your account."),
            HttpStatusCode.Forbidden => new ForbiddenException(errorDetails?.Details ?? "You are not permitted to access this endpoint."),
            _ => new UnknownApiResponseException("Unknown response from the FlightRadar24 API could not be handled.")
        };
    }
    
    public void Dispose() => _httpClient.Dispose();
}