namespace FlightRadar.Core.Models.V1.Filters;

public class AltitudeRange
{
    public required int LowerLimit { get; set; }
    
    public required int UpperLimit { get; set; }

    public override string ToString() => $"{LowerLimit}-{UpperLimit}";
}