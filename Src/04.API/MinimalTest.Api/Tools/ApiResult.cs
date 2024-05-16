using System.Net;

namespace MinimalTest.Api.Tools
{
    public record ApiModel(HttpStatusCode StatusCode, string message, object? data);
    public static class ApiResult
    {
        public static ApiModel Success(string message, object? data)
            => new(HttpStatusCode.OK, message, data);

        public static ApiModel Failure(HttpStatusCode StatusCode, string message, object? data)
            => new(StatusCode, message, data);

        public static ApiModel ApiException()
            => new(HttpStatusCode.InternalServerError, "Error Try Again Later", new { });
    }
}
