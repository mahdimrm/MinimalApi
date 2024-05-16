using ApplicationService.Todo.Commands;
using ApplicationService.Todo.Queries.GetTodo;
using Carter;
using MediatR;
using MinimalTest.Api.Tools;

namespace MinimalTest.Api.EndPoints.Todo
{
    public class TodoEndPoints : CarterModule
    {
        public TodoEndPoints() : base("/Todo") { }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Get", async (ISender sender) =>
            {
                var query = new GetTodoQuery();

                var result = await sender.Send(query);

                return ApiResult.Success("", new { Todos = result });
            });

            app.MapPost("/Create", async (CreateTodoItemCommand request, ISender sender) =>
            {
                var result = await sender.Send(request);

                return result.StatusHandler();
            });

            app.MapPost("/Update", async (UpdateTodoItemCommand request, ISender sender) =>
            {
                var result = await sender.Send(request);
                return result.StatusHandler();
            });

            app.MapPost("/Delete", async (DeleteTodoItemCommand request, ISender sender) =>
            {
                var result = await sender.Send(request);

                return result.StatusHandler();
            });
        }
    }
}
