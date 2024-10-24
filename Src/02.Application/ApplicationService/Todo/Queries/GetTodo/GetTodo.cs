namespace ApplicationService.Todo.Queries.GetTodo;

public record GetTodoQuery : IRequest<IEnumerable<TodosListDto>>
{
}
public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoQuery, IEnumerable<TodosListDto>>
{
    private readonly IQuery<TodoItem> _todoQuery;

    public GetTodoItemsQueryHandler(IQuery<TodoItem> todoQuery)
    {
        _todoQuery = todoQuery;
    }

    public async Task<IEnumerable<TodosListDto>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<TodoItem, TodosListDto>> selector = x => new TodosListDto(x.Id, x.Title, x.Description);

        return await _todoQuery.GetAllAsync(selector);
    }
}