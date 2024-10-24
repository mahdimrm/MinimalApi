using FluentValidation;

namespace ApplicationService.Todo.Commands
{
    public record CreateTodoItemCommand : IRequest<Either<ServiceStatus, TodoItem>>
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Either<ServiceStatus, TodoItem>>
    {
        private readonly ICud<TodoItem> _toDoItemCud;
        private readonly IValidator<CreateTodoItemCommand> _validator;

        public CreateTodoItemCommandHandler(ICud<TodoItem> toDoItemCud, IValidator<CreateTodoItemCommand> validator)
        {
            _toDoItemCud = toDoItemCud;
            _validator = validator;
        }

        public async Task<Either<ServiceStatus, TodoItem>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoItem entity = CreateTodo(request);

            entity.AddDomainEvent(new CreateTodoBaseEvent(entity));

            return await _toDoItemCud.AddAsync(entity) ? entity : ServiceStatus.Failed;
        }

        private static TodoItem CreateTodo(CreateTodoItemCommand request)
            => new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsDone = false
            };
    }
}
