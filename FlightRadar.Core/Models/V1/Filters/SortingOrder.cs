using System.ComponentModel;

namespace FlightRadar.Core.Models.V1.Filters;

public enum SortingOrder
{
    [Description("asc")]
    Ascending,
    [Description("desc")]
    Descending
}