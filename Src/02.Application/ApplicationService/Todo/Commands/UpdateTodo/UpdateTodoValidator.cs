using ApplicationService.Todo.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(500)
            .NotEmpty();
    }
}
