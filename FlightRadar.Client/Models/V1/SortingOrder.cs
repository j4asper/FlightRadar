using System.ComponentModel;

namespace FlightRadar.Client.Models.V1;

public enum SortingOrder
{
    [Description("asc")]
    Ascending,
    [Description("desc")]
    Descending
}