[![NuGet Version](https://img.shields.io/nuget/v/FlightRadar?style=for-the-badge&logo=NuGet&logoColor=F7BF24&label=Version&color=F7BF24)](https://www.nuget.org/packages/FlightRadar)
[![NuGet Downloads](https://img.shields.io/nuget/dt/FlightRadar?style=for-the-badge&logo=NuGet&logoColor=F7BF24&label=Downloads&color=F7BF24)](https://www.nuget.org/packages/FlightRadar)

![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/j4asper/flightradar/unit-tests.yml?branch=main&style=for-the-badge&logo=githubactions&logoColor=F7BF24&label=Unit%20Tests&color=F7BF24)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/j4asper/flightradar/nuget-release.yml?branch=main&style=for-the-badge&logo=githubactions&logoColor=F7BF24&label=Release%20Workflow&color=F7BF24)


# FlightRadar

This is an unofficial FlightRadar24 API wrapper designed to provide easy and efficient access to the FlightRadar24 data. It supports all current v1 endpoints, enabling you to retrieve a wide range of real-time flight information directly into your applications.

## Official API Documentation

For more details on the available endpoints and how to use the official FlightRadar24 API, visit the official documentation here https://fr24api.flightradar24.com/docs/getting-started.

## Installation

You can install the FlightRadar library from NuGet by running the following command in your project:

```
dotnet add package FlightRadar
```

Alternatively, you can add it via the NuGet Package Manager in Visual Studio or by editing your .csproj file directly.

## FlightRadar Client Examples

### Setup

```csharp
// Initialize the client with your API key
var flightRadarClient = new FlightRadarClient("YOUR_API_KEY");
```

### Airport Information

```csharp
// Get detailed airport information
var airportDetails = await flightRadarClient.V1.GetDetailedAirportInfoByCodeAsync("KJFK");
Console.WriteLine($"Airport: {airportDetails?.Name}, Location: {airportDetails?.City}, {airportDetails?.Country}");

// Get basic airport information
var airport = await flightRadarClient.V1.GetAirportInfoByCodeAsync("EGLL");
Console.WriteLine($"Airport: {airport?.Name} (IATA: {airport?.IataCode})");
```

### Airlines

```csharp
// Get airline information by ICAO code
var airline = await flightRadarClient.V1.GetAirlineInfoByIcaoAsync("UAL");
Console.WriteLine($"Airline: {airline?.Name} ({airline?.IcaoCode})");
```

### Flight Positions

```csharp
// Get current flight positions with filtering
var currentFlights = await flightRadarClient.V1.GetFullFlightPositionsAsync(new FlightPositionsFilter 
{
    Callsigns = ["UAL123", "DLH456"],
    // You can also filter by:
    // - Bounds (geographical rectangle)
    // Airports
});

foreach (var flight in currentFlights)
{
    Console.WriteLine($"Flight: {flight.Callsign}, Altitude: {flight.Altitude}ft, Speed: {flight.GroundSpeed}kts");
}

// Get count of flights matching criteria
var count = await flightRadarClient.V1.GetFlightPositionsCountAsync(new FlightPositionsFilter
{
    OperatingAs = ["SAS", "BAW"]
});
Console.WriteLine($"Found {count} flights operating for SAS and British Airways");
```

### Historical Data

```csharp
// Get historical flight positions
var historicPositions = await flightRadarClient.V1.GetFullHistoricFlightPositionsAsync(new HistoricFlightPositionFilter
{
    Timestamp = DateTime.Now.AddDays(-1),
    Callsigns = ["AFR1234"]
});

foreach (var position in historicPositions)
{
    Console.WriteLine($"Historic position: {position.Callsign} at {position.Timestamp}, Alt: {position.Altitude}ft");
}
```

### Flight Summaries

```csharp
// Get detailed flight summary
var flightSummary = await flightRadarClient.V1.GetFullFlightSummaryAsync(new FlightSummaryFilter
{
    FlightIds = ["12345abc"]
});

if (flightSummary != null && flightSummary.Any())
{
    var flight = flightSummary.First();
    Console.WriteLine($"Flight: {flight.Callsign}, From: {flight.DepartureIcaoCode} To: {flight.DestinationIcaoCode}");
}
```

### Flight Tracks

```csharp
// Get flight track history by flight ID
var tracks = await flightRadarClient.V1.GetFlightTracksByFlightIdAsync("34242a02");

if (tracks.Any())
{
    var firstTrack = tracks.First();
    Console.WriteLine($"Track path points: {firstTrack.Tracks.Count()}, Source: {firstTrack.Tracks.First().Source}");
    
    // Process individual track points
    foreach (var point in firstTrack.Tracks.Take(5))
    {
        Console.WriteLine($"Time: {point.Timestamp}, Lat: {point.Latitude}, Lon: {point.Longitude}, Alt: {point.Altitude}");
    }
}
```

### API Usage Stats

```csharp
// Check your API usage
var usageStats = await flightRadarClient.V1.GetApiUsageAsync(TimePeriod.Last24Hours);

foreach (var stat in usageStats)
{
    Console.WriteLine($"Endpoint: {stat.Endpoint}, Requests: {stat.RequestCount}, Credits used: {stat.Credits}");
}
```