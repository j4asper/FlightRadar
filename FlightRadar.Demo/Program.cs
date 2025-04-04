using FlightRadar.Client;
using FlightRadar.Client.Models.V1;

namespace FlightRadar.Demo;

class FlightRadarDemo
{
    static async Task Main(string[] args)
    {
        var flightRadarClient = new FlightRadarClient("your-flightradar24-api-key");

        // Use Airlines Light Endpoint
        var airline = await flightRadarClient.V1.GetAirlineInfoByIcaoAsync("AAL");
        Console.WriteLine($"Airline: {airline?.Name}");
        // Output: Airline: American Airlines
        
        // Use Airports Full Endpoint
        var airportDetailed = await flightRadarClient.V1.GetDetailedAirportInfoByCodeAsync("ESSA");
        Console.WriteLine($"Airport: {airportDetailed?.Name}");
        // Output: Airport: Stockholm Arlanda Airport
        
        // Use Airports Light Endpoint
        var airport = await flightRadarClient.V1.GetAirportInfoByCodeAsync("ESSA");
        Console.WriteLine($"Airport: {airport?.Name}");
        // Output: Airport: Stockholm Arlanda Airport
        
        // Use Full Flight Positions Endpoint
        var fullFlightPositions = await flightRadarClient.V1.GetFullFlightPositionsAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {fullFlightPositions?.First().Altitude}");
        // Output: Flight Altitude: 37000
        
        // Use Light Flight Positions Endpoint
        var lightFlightPositions = await flightRadarClient.V1.GetFlightPositionsAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Flight Altitude: {lightFlightPositions?.First().Altitude}");
        // Output: Flight Altitude: 40000
        
        // Use Flight Positions Count Endpoint
        var flightPositionsCount = await flightRadarClient.V1.GetFlightPositionsCountAsync(new FlightPositionsFilter()
        {
            Callsigns = ["AFR1463"]
        });
        Console.WriteLine($"Count: {flightPositionsCount}");
        // Output: Count: 123
        
        // Use Flight Tracks Endpoint
        var flightTracks = await flightRadarClient.V1.GetFlightTracksByFlightIdAsync("34242a02");
        Console.WriteLine($"FlightTrack Source: {flightTracks?.First().Tracks.First().Source}");
        // Output: FlightTrack Source: MLAT
        
        // Use Flight Tracks Endpoint
        var usage = await flightRadarClient.V1.GetApiUsageAsync(TimePeriod.Last24Hours);
        Console.WriteLine($"Used: {usage?.First().Endpoint} {usage?.First().RequestCount} times");
        // Output: Used: airports/{code} 5 times
    }
}