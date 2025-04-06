using System.Globalization;

namespace FlightRadar.Core.Models.V1.Filters;

/// <summary>
/// Coordinates defining an area. Order: north, south, west, east. Up to 3 decimal points will be processed.
/// </summary>
public class BoundingBox
{
    public double North { get; private set; }
    public double South { get; private set; }
    public double West { get; private set; }
    public double East { get; private set; }

    public BoundingBox(double north, double south, double west, double east)
    {
        North = north;
        South = south;
        West = west;
        East = east;
    }

    public override string ToString() => $"{North.ToString(CultureInfo.InvariantCulture)},{South.ToString(CultureInfo.InvariantCulture)},{West.ToString(CultureInfo.InvariantCulture)},{East.ToString(CultureInfo.InvariantCulture)}";
}