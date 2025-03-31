using FlightRadar.Client.Extensions;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Client.Models.V1;

public class FlightPositionsFilter
{
    /// <summary>
    /// Coordinates defining an area. Order: north, south, west, east. Up to 3 decimal points will be processed.
    /// </summary>
    /// <remarks>Max 4 elements</remarks>
    public List<double> Bounds { get; set; } = [];
    
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
    /// Flight altitude ranges represent the aircraft's barometric pressure altitude above mean sea level (AMSL), measured under standard atmospheric conditions (1013.25 hPa / 29.92 in. Hg.). Altitudes are expressed in feet, starting from 0, where 0 reflects ground level AMSL.
    /// </summary>
    public List<AltitudeRange> AltitudeRanges { get; set; } = [];
    
    /// <summary>
    /// Squawk codes in hex format.
    /// </summary>
    public List<string> Squawks { get; set; } = [];

    /// <summary>
    /// Categories of Flights.
    /// </summary>
    public List<FlightCategory> Categories { get; set; } = [];

    /// <summary>
    /// Source of information about flights.
    /// </summary>
    public List<DataSource> DataSources { get; set; } = [];
    
    /// <summary>
    /// Flight information region in lower or upper airspace.
    /// </summary>
    public List<string> Airspaces { get; set; } = [];
    
    /// <summary>
    /// Flight ground speed (in knots). Accepts single value or range.
    /// </summary>
    /// <example>120-140 | 80 | 0-40</example>
    public string? GroundSpeed { get; set; }

    /// <summary>
    /// Limit of results.
    /// </summary>
    /// <remarks>Max value 30000</remarks>
    public int? Limit { get; set; }
    
    public override string ToString()
    {
        List<string> queryElements = [];

        if (Bounds.Any())
            queryElements.Add($"bounds={string.Join(",", Bounds)}");
        
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
        
        if (AltitudeRanges.Any())
            queryElements.Add($"altitude_ranges={string.Join(",", AltitudeRanges)}");
        
        if (Squawks.Any())
            queryElements.Add($"squawks={string.Join(",", Squawks)}");
        
        if (Categories.Any())
            queryElements.Add($"categories={string.Join(",", Categories.Select(c => c.GetDescription()))}");
        
        if (DataSources.Any())
            queryElements.Add($"data_sources={string.Join(",", DataSources.Select(x => x.ToString().ToUpper()))}");
        
        if (Airspaces.Any())
            queryElements.Add($"airspaces={string.Join(",", Airspaces)}");
        
        if (GroundSpeed != null)
            queryElements.Add($"gspeed={GroundSpeed}");
        
        if (Limit is not null)
            queryElements.Add($"limit={Limit}");
        
        return string.Join("&", queryElements);
    }
}