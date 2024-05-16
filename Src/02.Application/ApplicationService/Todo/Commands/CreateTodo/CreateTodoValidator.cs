using FluentValidation;

namespace ApplicationService.Todo.Commands
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Description)
                .MaximumLength(500)
                .NotEmpty();
        }
    }
}

