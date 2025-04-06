namespace FlightRadar.Entities.Models.V1;

public class FlightSummaryFull : FlightSummaryLight
{
    /// <summary>
    /// Identifier of the runway used for takeoff.
    /// </summary>
    public string? RunwayTakeoff { get; set; }

    /// <summary>
    /// The actual destination airport (different when diverted).
    /// </summary>
    public Code? ActualDestinationAirport { get; set; }

    /// <summary>
    /// Identifier of the runway used for landing.
    /// </summary>
    public string? RunwayLanded { get; set; }

    /// <summary>
    /// Duration of the flight from takeoff to landing.
    /// </summary>
    public TimeSpan? FlightTime { get; set; }

    /// <summary>
    /// Actual ground distance the aircraft traveled (in km).
    /// </summary>
    public float? ActualDistance { get; set; }

    /// <summary>
    /// Great-circle distance between the first and last position (in km).
    /// </summary>
    public float? CircleDistance { get; set; }
}