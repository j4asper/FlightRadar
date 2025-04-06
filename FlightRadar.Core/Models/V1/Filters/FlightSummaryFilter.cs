using FlightRadar.Core.Extensions;

namespace FlightRadar.Core.Models.V1.Filters;

public class FlightSummaryFilter
{
    /// <summary>
    /// FlightRadar24 ids. Cannot be combined with <b>From</b> and <b>To</b>
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> FlightIds { get; set; } = [];
    
    /// <summary>
    /// Flight date lower range, uses <b>FirstSeen</b>.
    /// </summary>
    /// <remarks>Cannot be combined with FlightIds</remarks>
    public DateTime? From { get; set; }
    
    /// <summary>
    /// Flight date upper range, uses <b>FirstSeen</b>.
    /// </summary>
    /// <remarks>Cannot be combined with FlightIds</remarks>
    public DateTime? To { get; set; }
    
    /// <summary>
    /// Flight numbers.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> Flights { get; set; } = [];
    
    /// <summary>
    /// Flight callsigns.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> Callsigns { get; set; } = [];
    
    /// <summary>
    /// Aircraft registration numbers.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> Registrations { get; set; } = [];
    
    /// <summary>
    /// Aircraft painted in an airline's livery, identified by ICAO code, but not necessarily operated by that airline, such as a regional airline operating a flight for a larger airline.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> PaintedAs { get; set; } = [];
    
    /// <summary>
    /// Aircraft operating under an airline's call sign, identified by ICAO code, but not necessarily an aircraft belonging to that airline, such as an aircraft on lease from another airline.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> OperatingAs { get; set; } = [];
    
    public List<AirportFilter> Airports { get; set; } = [];
    
    /// <summary>
    /// Flights between different airports or countries. Airports specified by IATA or ICAO codes or countries specified by ISO 3166-1 alpha-2 codes.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> Routes { get; set; } = [];

    /// <summary>
    /// Aircraft ICAO type codes.
    /// </summary>
    /// <remarks>Max 15 elements</remarks>
    public List<string> Aircraft { get; set; } = [];
    
    /// <summary>
    /// Sorting order of the results by <b>FirstSeen</b>
    /// </summary>
    public SortingOrder SortingOrder { get; set; } = SortingOrder.Ascending;
    
    /// <summary>
    /// Limit of results.
    /// </summary>
    /// <remarks>Max value 20000</remarks>
    public int? Limit { get; set; } = null;

    public override string ToString()
    {
        List<string> queryElements = [];

        if (FlightIds.Any())
            queryElements.Add($"flight_ids={string.Join(",", FlightIds)}");
        
        if (From.HasValue)
            queryElements.Add($"flight_datetime_from={From.Value.ToUniversalIso8601()}");
        
        if (To.HasValue)
            queryElements.Add($"flight_datetime_to={To.Value.ToUniversalIso8601()}");
        
        if (Flights.Any())
            queryElements.Add($"flights={string.Join(",", Flights)}");
        
        if (Callsigns.Any())
            queryElements.Add($"callsigns={string.Join(",", Callsigns)}");
        
        if (Registrations.Any())
            queryElements.Add($"registrations={string.Join(",", Registrations)}");
        
        if (PaintedAs.Any())
            queryElements.Add($"painted_as={string.Join(",", PaintedAs)}");
        
        if (OperatingAs.Any())
            queryElements.Add($"operating_as={string.Join(",", OperatingAs)}");
        
        if (Airports.Any())
            queryElements.Add($"airports={string.Join(",", Airports)}");
        
        if (Routes.Any())
            queryElements.Add($"routes={string.Join(",", Routes)}");
        
        if (Aircraft.Any())
            queryElements.Add($"aircraft={string.Join(",", Aircraft)}");
        
        if (SortingOrder != SortingOrder.Ascending)
            queryElements.Add($"sort={SortingOrder.GetDescription()}");
        
        if (Limit is not null)
            queryElements.Add($"limit={Limit}");
        
        return string.Join("&", queryElements);
    }
}