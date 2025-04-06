using FlightRadar.Client;
using FlightRadar.Core.Models.V1.Filters;

namespace FlightRadar.Demo;

class FlightRadarDemo
{
    static async Task Main(string[] args)
    {
        var flightRadarClient = new FlightRadarClient("your-flightradar24-api-key");

        //
        // Use Airlines Light Endpoint
        //
        var airline = await flightRadarClient.V1.Airlines.GetByIcaoCodeAsync("AAL");
        Console.WriteLine($"Airline: {airline?.Name}");
        // Output: Airline: American Airlines
        
        
        //
        // Use Airports Full Endpoint
        //
        var airportDetailed = await flightRadarClient.V1.Airports.GetFullByCodeAsync("ESSA");
        Console.WriteLine($"Airport: {airportDetailed?.Name}");
        // Output: Airport: Stockholm Arlanda Airport
        
        
        //
        // Use Airports Light Endpoint
        //
        var airport = await flightRadarClient.V1.Airports.GetByCodeAsync("ESSA");
        Console.WriteLine($"Airport: {airport?.Name}");
        // Output: Airport: Stockholm Arlanda Airport
        
        
        //
        // Use Full Flight Positions Endpoint
        //
        var fullFlightPositions = await flightRadarClient.V1.FlightPositions.GetFullAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {fullFlightPositions.First().Altitude}");
        // Output: Flight Altitude: 37000
        
        
        //
        // Use Light Flight Positions Endpoint
        //
        var lightFlightPositions = await flightRadarClient.V1.FlightPositions.GetAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {lightFlightPositions.First().Altitude}");
        // Output: Flight Altitude: 40000
        
        
        //
        // Use Flight Positions Count Endpoint
        //
        var flightPositionsCount = await flightRadarClient.V1.FlightPositions.GetCountAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Count: {flightPositionsCount}");
        // Output: Count: 123
        
        
        //
        // Use Full Historic Flight Positions Endpoint
        //
        var fullHistoricFlightPositions = await flightRadarClient.V1.HistoricFlightPositions.GetFullAsync(new HistoricFlightPositionFilter()
        {
            Timestamp = new DateTime(2024, 1, 1),
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {fullHistoricFlightPositions.First().Altitude}");
        // Output: Flight Altitude: 37000
        
        
        //
        // Use Light Historic Flight Positions Endpoint
        //
        var lightHistoricFlightPositions = await flightRadarClient.V1.HistoricFlightPositions.GetAsync(new HistoricFlightPositionFilter()
        {
            Timestamp = new DateTime(2024, 1, 1),
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {lightHistoricFlightPositions.First().Altitude}");
        // Output: Flight Altitude: 40000
        
        
        //
        // Use Flight Historic Positions Count Endpoint
        //
        var flightHistoricPositionsCount = await flightRadarClient.V1.HistoricFlightPositions.GetCountAsync(new HistoricFlightPositionFilter()
        {
            Timestamp = new DateTime(2024, 1, 1),
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Count: {flightHistoricPositionsCount}");
        // Output: Count: 123
        
        
        
        //
        // Use Full Flight Summary Endpoint
        //
        var fullFlightSummary = await flightRadarClient.V1.FlightSummaries.GetFullAsync(new FlightSummaryFilter()
        {
            FlightIds = ["380ce8ef"],
            Flights = ["SK1415"]
        });
        Console.WriteLine($"Flight Callsign: {fullFlightSummary.First().Callsign}");
        // Output: Flight Altitude: 37000
        
        
        //
        // Use Light Flight Summary Endpoint
        //
        var lightFlightSummary = await flightRadarClient.V1.FlightSummaries.GetAsync(new FlightSummaryFilter()
        {
            FlightIds = ["380ce8ef"],
            Flights = ["SK1415"]
        });
        Console.WriteLine($"Flight: {lightFlightSummary.First().FlightNumber}");
        // Output: Flight Altitude: 40000
        
        
        //
        // Use Flight Summary Count Endpoint
        //
        var flightSummaryCount = await flightRadarClient.V1.FlightSummaries.GetCountAsync(new FlightSummaryFilter()
        {
            FlightIds = ["380ce8ef"],
            Flights = ["SK1415"]
        });
        Console.WriteLine($"Count: {flightHistoricPositionsCount}");
        // Output: Count: 123
        
        
        
        
        //
        // Use Flight Tracks Endpoint
        //
        var flightTracks = await flightRadarClient.V1.FlightTracks.GetByFlightIdAsync("34242a02");
        Console.WriteLine($"FlightTrack Source: {flightTracks?.First().Tracks.First().Source}");
        // Output: FlightTrack Source: MLAT
        
        
        //
        // Use Flight Tracks Endpoint
        //
        var usage = await flightRadarClient.V1.Usage.GetAsync(TimePeriod.Last24Hours);
        Console.WriteLine($"Used: {usage.First().Endpoint} {usage.First().RequestCount} times");
        // Output: Used: airports/{code} 5 times
    }
}