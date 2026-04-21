using FluentValidation;

namespace NetCATemplate.Application.Todos.Delete
{
    public sealed class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Todo ID must not be empty.");
        }
    }
}
