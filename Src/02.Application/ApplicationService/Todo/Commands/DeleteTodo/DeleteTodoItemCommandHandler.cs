using Events.Todo;

namespace ApplicationService.Todo.Commands;

public record DeleteTodoItemCommand : IRequest<Either<ServiceStatus, TodoItem>>
{
    public Guid Id { get; init; }
}

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, Either<ServiceStatus, TodoItem>>
{
    private readonly IQuery<TodoItem> _todoItemquery;
    private readonly ICud<TodoItem> _todoItemCud;

    public DeleteTodoItemCommandHandler(
        IQuery<TodoItem> todoItemquery,
        ICud<TodoItem> todoItemCud)
    {
        _todoItemquery = todoItemquery;
        _todoItemCud = todoItemCud;
    }

    public async Task<Either<ServiceStatus, TodoItem>> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoItemquery.GetAsync(request.Id);

        if (entity is null)
            return ServiceStatus.NotFound;

        entity.RemoveDomainEvent(new DeleteTodoBaseEvent(entity));

        return await _todoItemCud.DeleteAsync(entity) ? entity : ServiceStatus.Failed;
    }
}

