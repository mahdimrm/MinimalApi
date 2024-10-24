namespace ApplicationService.Todo.Commands;
public record UpdateTodoItemCommand : IRequest<Either<ServiceStatus, TodoItem>>
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string Description { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, Either<ServiceStatus, TodoItem>>
{
    private readonly IQuery<TodoItem> _todoItemQuery;
    private readonly ICud<TodoItem> _toDoItemCud;
    public UpdateTodoItemCommandHandler(
        ICud<TodoItem> toDoItemCud,
        IQuery<TodoItem> todoItemQuery)
    {
        _toDoItemCud = toDoItemCud;
        _todoItemQuery = todoItemQuery;
    }

    public async Task<Either<ServiceStatus, TodoItem>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        TodoItem todo = await _todoItemQuery.FindAsync(request.Id);
        if (todo is null)
            return ServiceStatus.NotFound;

        UpdateTodo(request, todo);

        return await _toDoItemCud.UpdateAsync(todo) ? todo : ServiceStatus.Failed;
    }

    private static void UpdateTodo(UpdateTodoItemCommand request, TodoItem todo)
    {
        todo.Title = request.Title;
        todo.Description = request.Description;
    }
}

