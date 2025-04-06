namespace FlightRadar.Entities.Models.V1;

public class AirportFull : AirportLight
{
    /// <summary>
    /// Longitude expressed in decimal degrees.
    /// </summary>
    public required double Longitude { get; set; }

    /// <summary>
    /// Latitude expressed in decimal degrees.
    /// </summary>
    public required double Latitude { get; set; }

    /// <summary>
    /// Airport elevation in feet (e.g., 150).
    /// </summary>
    public required int Elevation { get; set; }

    /// <summary>
    /// Country information.
    /// </summary>
    public required Country Country { get; set; }

    /// <summary>
    /// City where the airport is located (e.g., "Stockholm").
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// State where the airport is located (nullable, only available for certain countries).
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Timezone information.
    /// </summary>
    public required Timezone Timezone { get; set; }
}

public class Country
{
    /// <summary>
    /// Name of the country.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country.
    /// </summary>
    public required string Code { get; set; }
}

public class Timezone
{
    /// <summary>
    /// Name of the timezone (e.g., "Europe/Stockholm").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Offset from UTC in seconds (e.g., 7200).
    /// </summary>
    public required int Offset { get; set; }
}