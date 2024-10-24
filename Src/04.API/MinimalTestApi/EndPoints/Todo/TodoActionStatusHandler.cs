using ApplicationService.Todo;
using Entities;
using LanguageExt;
using MinimalTest.Api.Tools;
using System.Net;

namespace MinimalTest.Api.EndPoints.Todo
{
    public static class TodoActionStatusHandler
    {
        public static ApiModel StatusHandler(this Either<ServiceStatus, TodoItem> result)
        {
            return result.Match(
                        Left: status =>
                        {
                            return status switch
                            {
                                ServiceStatus.Failed => ApiResult.Failure(HttpStatusCode.InternalServerError, "Error Please Try Again Later", null),
                                ServiceStatus.NotFound => ApiResult.Failure(HttpStatusCode.NotFound, "Todo Was Not Found", ""),
                                _ => ApiResult.ApiException()
                            };
                        },
                        Right: todo => ApiResult.Success("The desired operation was completed successfully", todo));
        }
    }
}
