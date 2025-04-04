namespace FlightRadar.Client.Models.V1.ResponseModels;

public class ErrorResponseModel
{
    public required string Message { get; set; }
    public string? Details { get; set; }
}