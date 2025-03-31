using FlightRadar.Client.Clients;

namespace FlightRadar.Client;

public class FlightRadarClient : IDisposable
{
    /// <summary>
    /// All v1 endpoints.
    /// </summary>
    public V1Client V1 { get; private set; }

    public FlightRadarClient(string flightRadarApiKey)
    {
        V1 = new V1Client(flightRadarApiKey);
    }

    public void Dispose()
    {
        V1.Dispose();
    }
}