using System.ComponentModel;

namespace FlightRadar.Core.Models.V1.Filters;

public enum TimePeriod
{
    [Description("24h")]
    Last24Hours,
    [Description("7d")]
    Last7Days,
    [Description("30d")]
    Last30Days,
    [Description("1y")]
    LastYear
}