namespace FlightRadar.Client.Exceptions;

public class UnknownApiResponseException : Exception
{
    public UnknownApiResponseException()
    {
    }

    public UnknownApiResponseException(string message)
        : base(message)
    {
    }

    public UnknownApiResponseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}