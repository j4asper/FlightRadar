using System.Net;
using System.Net.Http.Json;
using FlightRadar.Core.Exceptions;
using FlightRadar.Core.Models.V1.ResponseModels;

namespace FlightRadar.Client.Exceptions;

internal static class ApiExceptionHandler
{
    internal static async Task<Exception> ThrowOnUnexpectedResponse(HttpResponseMessage response)
    {
        var errorDetails = await response.Content.ReadFromJsonAsync<ErrorResponseModel>();

        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new ValidationException(errorDetails?.Details ?? "Validation failed."),
            HttpStatusCode.Unauthorized => new UnauthenticatedException(errorDetails?.Details ?? "The FlightRadar24 API Key is invalid."),
            HttpStatusCode.PaymentRequired => new PaymentRequiredException(errorDetails?.Details ?? "Credit limit reached. Please top up your account."),
            HttpStatusCode.Forbidden => new ForbiddenException(errorDetails?.Details ?? "You are not permitted to access this endpoint."),
            _ => new UnknownApiResponseException("Unknown response from the FlightRadar24 API could not be handled.")
        };
    }
}