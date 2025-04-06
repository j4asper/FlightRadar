using FlightRadar.Client.Clients;
using FlightRadar.Core.Clients;

namespace FlightRadar.Client;

public class FlightRadarClient : IDisposable
{
    /// <summary>
    /// All v1 endpoints.
    /// </summary>
    public IV1Client V1 { get; }

    public FlightRadarClient(string flightRadarApiKey)
    {
        V1 = new V1Client(flightRadarApiKey);
    }

    public void Dispose()
    {
        V1.Dispose();
    }
}